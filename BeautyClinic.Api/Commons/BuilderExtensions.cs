using System.Text;
using BeautyClinic.Api.Providers;
using BeautyClinic.Api.Services;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Appointment;
using BeautyClinic.Core.Interfaces.Auth;
using BeautyClinic.Core.Interfaces.Consulation;
using BeautyClinic.Core.Interfaces.Patient;
using BeautyClinic.Core.Interfaces.Person;
using BeautyClinic.Core.Interfaces.Procedure;
using BeautyClinic.Core.Models.Auth;
using BeautyClinic.Core.Services;
using BeautyClinic.Core.Services.Appointment;
using BeautyClinic.Core.Services.Auth;
using BeautyClinic.Core.Services.Consulation;
using BeautyClinic.Core.Services.Patient;
using BeautyClinic.Core.Services.Person;
using BeautyClinic.Core.Services.Procedure;
using BeautyClinic.Infrastructure.Context;
using BeautyClinic.Infrastructure.Repositories;
using BeautyClinic.Infrastructure.Repositories.Appointment;
using BeautyClinic.Infrastructure.Repositories.Auth;
using BeautyClinic.Infrastructure.Repositories.Consulation;
using BeautyClinic.Infrastructure.Repositories.Patient;
using BeautyClinic.Infrastructure.Repositories.Person;
using BeautyClinic.Infrastructure.Repositories.Procedure;
using BeautyClinic.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BeautyClinic.Api.Commons;

public static class BuilderExtensions
{
    extension(WebApplicationBuilder builder)
    {
        public void AddConfigurations()
        {
            Configurations.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            Configurations.JwtSecret = builder.Configuration["Jwt:Secret"] ?? string.Empty;
            Configurations.JwtIssuer = builder.Configuration["Jwt:Issuer"] ?? string.Empty;
            Configurations.JwtAudience = builder.Configuration["Jwt:Audience"] ?? string.Empty;
            Configurations.JwtExpiration = builder.Configuration["Jwt:ExpirationMinutes"] ?? string.Empty;
            Configurations.RefreshTokenExpirationDays = builder.Configuration["Jwt:RefreshTokenExpirationDays"] ?? string.Empty;
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ITenantProvider, TenantProvider>();
        }

        public void AddAuthentication()
        {
            builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.User.RequireUniqueEmail = false; // e-mail único por clínica, não globalmente
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddPasswordValidator<PasswordValidator<User>>();

            builder.Services.AddScoped<IPasswordHasher<User>, Argon2PasswordHasher>();

            var key = Encoding.ASCII.GetBytes(Configurations.JwtSecret);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = Configurations.JwtIssuer,
                    ValidateAudience = true,
                    ValidAudience = Configurations.JwtAudience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddAuthorization();
        }

        public void AddDbContext()
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(Configurations.ConnectionString,
                    ServerVersion.AutoDetect(Configurations.ConnectionString)));
        }

        public void AddRepositories()
        {
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<IBodyAnamnesisRepository, BodyAnamnesisRepository>();
            builder.Services.AddScoped<IFacialAnamnesisRepository, FacialAnamnesisRepository>();
            builder.Services.AddScoped<IFemaleHabitsRepository, FemaleHabitsRepository>();
            builder.Services.AddScoped<IHabitsRepository, HabitsRepository>();
            builder.Services.AddScoped<IMeasurementsRepository, MeasurementsRepository>();
            builder.Services.AddScoped<IPatientHistoryRepository, PatientHistoryRepository>();
            builder.Services.AddScoped<IIndividualRepository, IndividualRepository>();
            builder.Services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IProcedurePackRepository, ProcedurePackRepository>();
            builder.Services.AddScoped<IProcedureRepository, ProcedureRepository>();
            builder.Services.AddScoped<IProcedurePackProcedureRepository, ProcedurePackProcedureRepository>();
            builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        }

        public void AddServices()
        {
            builder.Services.AddScoped(typeof(IService<>), typeof(BaseService<>));

            builder.Services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddScoped<IAddressService, AddressService>();
            builder.Services.AddScoped<IBodyAnamnesisService, BodyAnamnesisService>();
            builder.Services.AddScoped<IFacialAnamnesisService, FacialAnamnesisService>();
            builder.Services.AddScoped<IFemaleHabitsService, FemaleHabitsService>();
            builder.Services.AddScoped<IHabitsService, HabitsService>();
            builder.Services.AddScoped<IMeasurementsService, MeasurementsService>();
            builder.Services.AddScoped<IPatientHistoryService, PatientHistoryService>();
            builder.Services.AddScoped<IIndividualService, IndividualService>();
            builder.Services.AddScoped<IProfessionalService, ProfessionalService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IProcedurePackService, ProcedurePackService>();
            builder.Services.AddScoped<IProcedureService, ProcedureService>();
            builder.Services.AddScoped<IProcedurePackProcedureService, ProcedurePackProcedureService>();
        }
    }
}
