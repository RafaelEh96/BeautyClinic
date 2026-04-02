using BeautyClinic.Core.DTOs.Consultation;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Extensions;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Consulation;
using BeautyClinic.Core.Interfaces.Patient;
using BeautyClinic.Core.Models.Consulation;

namespace BeautyClinic.Core.Services.Consulation;

public class FacialAnamnesisService(IFacialAnamnesisRepository repository,
    IPatientHistoryService patientHistoryService,
    IHabitsService habitsService,
    IFemaleHabitsService femaleHabitsService,
    IUnitOfWork unitOfWork)
    : BaseService<FacialAnamnesis>(repository, unitOfWork), IFacialAnamnesisService
{
    public async Task<FacialAnamnesisDto> CreateFacialAnamnesisAsync(FacialAnamnesisDto dto)
    {
        return await CreateOrUpdateFacialAnamnesisDto(dto);
    }

    public async Task<FacialAnamnesisDto> GetFaciaAnamnesisByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if(entity is null)
            throw new ResourceNotFoundException("Anamnese não encontrada.");
        
        var femaleHabits = femaleHabitsService.GetFemaleHabitsByClientId(entity.ClientId);
        var habits = habitsService.GetHabitsByClientId(entity.ClientId);
        var patientHistory = patientHistoryService.GetPatientHistoryByClientId(entity.ClientId);
        await Task.WhenAll(femaleHabits, habits, patientHistory);
        
        var result = entity.MapToDto();
        result.FemaleHabits = femaleHabits.Result;
        result.Habits = habits.Result;
        result.PatientHistory = patientHistory.Result;
        
        return result;
    }

    public Task<FacialAnamnesisDto> UpdateFacialAnamnesisAsync(FacialAnamnesisDto dto)
    {
        return CreateOrUpdateFacialAnamnesisDto(dto);
    }

    private async Task<FacialAnamnesisDto> CreateOrUpdateFacialAnamnesisDto(FacialAnamnesisDto dto)
    {
        var facialAnamnesisResult = new FacialAnamnesisDto();
        await ExecuteInTransactionAsync(async () =>
        {
            var facialAnamnesis = dto.MapToEntity();

            facialAnamnesis = await InsertOrUpdateAsync(facialAnamnesis);
            var patientHistory = await patientHistoryService.InsertOrUpdateAsync(dto.PatientHistory.MapToEntity());
            var habits = await habitsService.InsertOrUpdateAsync(dto.Habits.MapToEntity());
            var femaleHabits = await femaleHabitsService.InsertOrUpdateAsync(dto.FemaleHabits.MapToEntity());
            
            facialAnamnesisResult = facialAnamnesis.MapToDto();
            facialAnamnesisResult.PatientHistory = patientHistory.MapToDto();
            facialAnamnesisResult.Habits = habits.MapToDto();
            facialAnamnesisResult.FemaleHabits = femaleHabits.MapToDto();
        });
        return facialAnamnesisResult;
    }
}
