using BeautyClinic.Core.DTOs.Clinic;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Extensions;
using BeautyClinic.Core.Interfaces.Clinic;
using BeautyClinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BeautyClinic.Infrastructure.Repositories.Clinic;

public class ClinicRepository(AppDbContext context) : IClinicRepository
{
    private readonly DbSet<Core.Models.Clinic.Clinic> clinicContext = context.Clinics;

    public async Task<ClinicDto> CreateClinicAsync(ClinicDto dto)
    {
        var clinic = new Core.Models.Clinic.Clinic
        {
            Id = GuidExtensions.NewId(),
            Name = dto.Name,
            Document = dto.Document
        };
        clinicContext.Add(clinic);
        await context.SaveChangesAsync();

        var createdClinic = clinic.MapToDto();
        return createdClinic;
    }

    public async Task<ClinicDto> UpdateClinicAsync(ClinicDto dto, Guid id)
    {
        var clinic = await clinicContext.FindAsync(id);
        if (clinic == null)
            throw new ResourceNotFoundException("Clinic not found");
        clinic = dto.MapToEntity();
        await context.SaveChangesAsync();
        var updatedClinic = clinic.MapToDto();
        return updatedClinic;
    }
}
