using BeautyClinic.Api.Middlewares;
using Microsoft.AspNetCore.Identity;

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

        public async Task SeedRolesAsync()
        {
            using var scope = app.Services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            string[] roles = ["Admin", "Professional", "Receptionist"];
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole<Guid>(role));
            }
        }
    }
}
