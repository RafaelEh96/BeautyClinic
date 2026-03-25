using BeautyClinic.Api.Providers;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Appointment;
using BeautyClinic.Core.Interfaces.Consulation;
using BeautyClinic.Core.Interfaces.Patient;
using BeautyClinic.Core.Interfaces.Person;
using BeautyClinic.Core.Interfaces.Procedure;
using BeautyClinic.Core.Services;
using BeautyClinic.Core.Services.Appointment;
using BeautyClinic.Core.Services.Consulation;
using BeautyClinic.Core.Services.Patient;
using BeautyClinic.Core.Services.Person;
using BeautyClinic.Core.Services.Procedure;
using BeautyClinic.Infrastructure.Context;
using BeautyClinic.Infrastructure.Repositories;
using BeautyClinic.Infrastructure.Repositories.Appointment;
using BeautyClinic.Infrastructure.Repositories.Consulation;
using BeautyClinic.Infrastructure.Repositories.Patient;
using BeautyClinic.Infrastructure.Repositories.Person;
using BeautyClinic.Infrastructure.Repositories.Procedure;
using BeautyClinic.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BeautyClinic.Api.Commons;

public static class BuilderExtensions
{
    extension(WebApplicationBuilder builder)
    {
        public void AddConfigurations()
        {
            Configurations.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ITenantProvider, TenantProvider>();
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
        }

        public void AddServices()
        {
            builder.Services.AddScoped(typeof(IService<>), typeof(BaseService<>));

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
