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
    public async Task<BodyAnamnesisDto> GetBodyAnamnesisByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdWithDetailsAsync(id);
        if (entity is null)
            throw new ResourceNotFoundException("Anamnese não encontrada.");

        var result = entity.MapToDto();
        result.Measurement = entity.Measurement.MapToDto();

        var femaleHabitsTask = femaleHabitsService.GetFemaleHabitsByClientId(entity.ClientId);
        var habitsTask = habitsService.GetHabitsByClientId(entity.ClientId);
        var patientHistoryTask = patientHistoryService.GetPatientHistoryByClientId(entity.ClientId);

        await Task.WhenAll(femaleHabitsTask, habitsTask, patientHistoryTask);

        result.FemaleHabits = femaleHabitsTask.Result;
        result.Habits = habitsTask.Result;
        result.PatientHistory = patientHistoryTask.Result;
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

            bodyAnamnesis = await InsertOrUpdateAsync(bodyAnamnesis);
            measurement = await measurementsService.InsertOrUpdateAsync(measurement);
            patientHistory = await patientHistoryService.InsertOrUpdateAsync(patientHistory);
            
            var habits = await habitsService.InsertOrUpdateAsync(dto.Habits.MapToEntity());
            var femaleHabits = await femaleHabitsService.InsertOrUpdateAsync(dto.FemaleHabits.MapToEntity());
            
            bodyAnamnesisResult = bodyAnamnesis.MapToDto();
            bodyAnamnesisResult.Measurement = measurement.MapToDto();
            bodyAnamnesisResult.PatientHistory = patientHistory.MapToDto();
            bodyAnamnesisResult.Habits = habits.MapToDto();
            bodyAnamnesisResult.FemaleHabits = femaleHabits.MapToDto();
        });

        return bodyAnamnesisResult;
    }
}