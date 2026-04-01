namespace BeautyClinic.Api.Commons;

public static class AppExtensions
{
    extension(WebApplication app)
    {
        public void AddDevConfiguration()
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger().RequireAuthorization();
        }

        public void UseSecurity()
        {
            app.UseAuthorization();
            app.UseAuthentication();
        }
    }
}