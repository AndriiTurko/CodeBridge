using CodeBridge.BLL.Interfaces;
using CodeBridge.BLL.Services;
using CodeBridge.DAL;
using CodeBridge.DAL.Interfaces;
using CodeBridge.DbContexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CodeBridge.BLL.MappingProfiles;

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

            //services.AddDbContext<CodeBridgeContext>(options =>
            //    options.UseSqlServer(connectionString, providerOptions =>
            //        providerOptions.EnableRetryOnFailure()
            //        ));

            services.AddDbContext<CodeBridgeContext>(options => 
                options.UseSqlite(connectionString)); 

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
            //services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            //services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            //services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            //var mappingConfiguration = new MapperConfiguration(mc => mc.AddProfile(new DogProfile()));
            //
            //IMapper mapper = mappingConfiguration.CreateMapper();
            //
            //services.AddSingleton(mapper);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDogService, DogService>();

            services.AddControllers().AddNewtonsoftJson();
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

            app.UseExceptionHandler("/exception");

            //app.UseIpRateLimiting();

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
