namespace CodeBridge.Middleware
{
    public static class ConfigureMiddleware
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
