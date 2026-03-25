using BeautyClinic.Core.DTOs.Consultation;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Extensions;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Consulation;
using BeautyClinic.Core.Interfaces.Patient;
using BeautyClinic.Core.Models.Consulation;
using BeautyClinic.Core.Models.Patient;

namespace BeautyClinic.Core.Services.Consulation;

public class BodyAnamnesisService(
    IBodyAnamnesisRepository repository,
    IPatientHistoryService patientHistoryService,
    IHabitsService habitsService,
    IFemaleHabitsService femaleHabitsService,
    IMeasurementsService measurementsService,
    IUnitOfWork unitOfWork)
    : BaseService<BodyAnamnesis>(repository, unitOfWork), IBodyAnamnesisService
{
    public async Task<BodyAnamnesisDto> GetBodyAnamnesisByIdAsync(long id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new ResourceNotFoundException("Anamnese não encontrada.");

        var result = entity.MapToDto();
        var measurement = await measurementsService.GetByIdAsync(entity.MeasurementId);
        var femaleHabits = await femaleHabitsService.GetFemaleHabitsByClientId(entity.ClientId);
        var habits = await habitsService.GetHabitsByClientId(entity.ClientId);
        var patientHistory = await patientHistoryService.GetPatientHistoryByClientId(entity.ClientId);
        result.Measurement = measurement!.MapToDto();
        result.FemaleHabits = femaleHabits;
        result.Habits = habits;
        result.PatientHistory = patientHistory;
        return result;
    }

    public async Task<BodyAnamnesisDto> CreateBodyAnamnesis(BodyAnamnesisDto dto)
    {
        return await CreateOrUpdateBodyAnamnesisDto(dto);
    }

    public async Task<BodyAnamnesisDto> UpdateBodyAnamnesisAsync(BodyAnamnesisDto bodyAnamnesis)
    {
        return await CreateOrUpdateBodyAnamnesisDto(bodyAnamnesis);
    }
    
    private async Task<BodyAnamnesisDto> CreateOrUpdateBodyAnamnesisDto(BodyAnamnesisDto dto)
    {
        var bodyAnamnesisResult = new BodyAnamnesisDto();
        await ExecuteInTransactionAsync(async () =>
        {
            var bodyAnamnesis = dto.MapToEntity();
            var measurement = dto.Measurement.MapToEntity();
            var patientHistory = dto.PatientHistory.MapToEntity();
            var habits = new Habits();
            var femaleHabits = new FemaleHabits();

            bodyAnamnesis = await InsertOrUpdateAsync(bodyAnamnesis);
            measurement = await measurementsService.InsertOrUpdateAsync(measurement);
            patientHistory = await patientHistoryService.InsertOrUpdateAsync(patientHistory);
            if (dto.Habits != null)
            {
                habits = dto.Habits.MapToEntity();
                habits.ClientId = dto.ClientId;
                habits = await habitsService.InsertOrUpdateAsync(habits);
            }

            if (dto.FemaleHabits != null)
            {
                femaleHabits = dto.FemaleHabits.MapToEntity();
                femaleHabits.ClientId = dto.ClientId;
                femaleHabits = await femaleHabitsService.InsertOrUpdateAsync(femaleHabits);
            }
            
            bodyAnamnesisResult = bodyAnamnesis.MapToDto();
            bodyAnamnesisResult.Measurement = measurement.MapToDto();
            bodyAnamnesisResult.PatientHistory = patientHistory.MapToDto();
            bodyAnamnesisResult.Habits = habits.MapToDto();
            bodyAnamnesisResult.FemaleHabits = femaleHabits.MapToDto();
        });

        return bodyAnamnesisResult;
    }
}