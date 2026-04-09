using System.Reflection;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Models.Appointment;
using BeautyClinic.Core.Models.Auth;
using BeautyClinic.Core.Models.Clinic;
using BeautyClinic.Core.Models.Consulation;
using BeautyClinic.Core.Models.Patient;
using BeautyClinic.Core.Models.Person;
using BeautyClinic.Core.Models.Procedure;
using BeautyClinic.Core.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeautyClinic.Infrastructure.Context;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    private readonly Guid _clinicId;

    public AppDbContext(DbContextOptions<AppDbContext> options, ITenantProvider tenantProvider) : base(options)
    {
        _clinicId = tenantProvider.GetClinicId();
    }

    public DbSet<Clinic> Clinics { get; set; } = null!;
    public DbSet<ProcedurePack> ProcedurePacks { get; set; } = null!;
    public DbSet<Procedure> Procedures { get; set; } = null!;
    public DbSet<ProcedurePackProcedure> ProcedurePackProcedures { get; set; } = null!;
    public DbSet<Individual> Individuals { get; set; }
    public DbSet<Professional> Professionals { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<BodyAnamnesis> BodyAnamnesises { get; set; }
    public DbSet<FacialAnamnesis> FacialAnamnesises { get; set; }
    public DbSet<FemaleHabits> FemaleHabits { get; set; }
    public DbSet<Habits> Habits { get; set; }
    public DbSet<Measurements> Measurements { get; set; }
    public DbSet<PatientHistory> PatientHistories { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Address>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<Appointment>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<BodyAnamnesis>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<FacialAnamnesis>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<FemaleHabits>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<Habits>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<Individual>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<Measurements>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<PatientHistory>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<Procedure>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<ProcedurePack>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<ProcedurePackProcedure>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<Professional>().HasQueryFilter(e => e.ClinicId == _clinicId);
        modelBuilder.Entity<RefreshToken>().HasQueryFilter(e => e.ClinicId == _clinicId);
    }
}
