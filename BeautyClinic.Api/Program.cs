using BeautyClinic.Api.Commons;
using BeautyClinic.Api.Endpoints;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfigurations();
builder.AddDbContext();
builder.AddAuthentication();
builder.AddRepositories();
builder.AddServices();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.AddDevConfiguration();

app.UseHttpsRedirection();

app.UseSecurity();

app.MapEndpoints();

await SeedRolesAsync(app);

app.Run();

static async Task SeedRolesAsync(WebApplication app)
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
