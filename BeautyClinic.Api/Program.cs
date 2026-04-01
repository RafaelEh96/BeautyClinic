using BeautyClinic.Api.Commons;
using BeautyClinic.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfigurations();
builder.AddDbContext();
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

app.Run();
