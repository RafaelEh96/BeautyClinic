using BeautyClinic.Api.Middlewares;

namespace BeautyClinic.Api.Commons;

public static class AppExtensions
{
    extension(WebApplication app)
    {
        public void AddDevConfiguration()
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public void UseSecurity()
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        public void UseGlobalExceptionHandler()
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
