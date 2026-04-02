using BeautyClinic.Core.DTOs.Consultation;
using BeautyClinic.Core.Models.Consulation;

namespace BeautyClinic.Core.Extensions;

public static class FacialAnamnesisExtension
{
    public static FacialAnamnesis MapToEntity(this FacialAnamnesisDto dto)
    {
        return new FacialAnamnesis
        {
            Id = dto.Id,
            FacialHairAlterationsPresent = dto.FacialHairAlterationsPresent,
            KeratinizationAlterationsPresent = dto.KeratinizationAlterationsPresent,
            LiquidContentFormationsPresent = dto.LiquidContentFormationsPresent,
            MainComplaints = dto.MainComplaints,
            MelaninRelatedPigmentSpotsPresent = dto.MelaninRelatedPigmentSpotsPresent,
            Notes = dto.Notes,
            OilinessClassification = dto.OilinessClassification,
            SensitivityClassification = dto.SensitivityClassification,
            SequelaeOrScarsPresent = dto.SequelaeOrScarsPresent,
            SkinClassification = dto.SkinClassification,
            SkinLesionsPresent = dto.SkinLesionsPresent,
            SkinThicknessClassification = dto.SkinThicknessClassification,
            VascularAlterationSpotsPresent = dto.VascularAlterationSpotsPresent,
            SolidFormationsPresent = dto.SolidFormationsPresent,
            ClientId = dto.ClientId,
        };
    }
    
    public static FacialAnamnesisDto MapToDto(this FacialAnamnesis entity)
    {
        return new FacialAnamnesisDto
        {
            ClientId = entity.ClientId,
            MainComplaints = entity.MainComplaints,
            ClinicId = entity.Client.ClinicId,
            FacialHairAlterationsPresent = entity.FacialHairAlterationsPresent,
            KeratinizationAlterationsPresent = entity.KeratinizationAlterationsPresent,
            SkinClassification = entity.SkinClassification,
            SkinThicknessClassification = entity.SkinThicknessClassification,
            OilinessClassification = entity.OilinessClassification,
            SensitivityClassification = entity.SensitivityClassification,
            Notes = entity.Notes,
            LiquidContentFormationsPresent = entity.LiquidContentFormationsPresent,
            SkinLesionsPresent = entity.SkinLesionsPresent,
            MelaninRelatedPigmentSpotsPresent = entity.MelaninRelatedPigmentSpotsPresent,
            VascularAlterationSpotsPresent = entity.VascularAlterationSpotsPresent,
            SequelaeOrScarsPresent = entity.SequelaeOrScarsPresent,
            SolidFormationsPresent = entity.SolidFormationsPresent,
            Id = entity.Id,
        };
    }
}