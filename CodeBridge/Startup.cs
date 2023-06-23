using AspNetCoreRateLimit;
using CodeBridge.BLL.Interfaces;
using CodeBridge.BLL.Services;
using CodeBridge.DAL;
using CodeBridge.DAL.Infrastructure;
using CodeBridge.DAL.Interfaces;
using CodeBridge.Middleware;
using Microsoft.EntityFrameworkCore;

namespace CodeBridge
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("Database");

            services.AddDbContext<CodeBridgeContext>(options =>
                options.UseSqlServer(connectionString, providerOptions =>
                    providerOptions.EnableRetryOnFailure()
                    ));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDogService, DogService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.ConfigureExceptionMiddleware();

            app.UseIpRateLimiting();

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
