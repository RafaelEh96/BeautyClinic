using BeautyClinic.Api.Commons;
using BeautyClinic.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfigurations();
builder.AddDbContext();
builder.AddAuthentication();
builder.AddRepositories();
builder.AddServices();
builder.Services.AddControllers();
builder.AddSwagger();

var app = builder.Build();

app.UseGlobalExceptionHandler();

if (app.Environment.IsDevelopment())
    app.AddDevConfiguration();

app.UseHttpsRedirection();

app.UseSecurity();

app.MapEndpoints();

await app.SeedRolesAsync();

app.Run();
