using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Enums;
using BeautyClinic.Core.Models.Patient;

namespace BeautyClinic.Core.DTOs.Consultation;

public class FacialAnamnesisDto
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public string MainComplaints { get; set; } = string.Empty;
    public bool MelaninRelatedPigmentSpotsPresent { get; set; }
    public bool VascularAlterationSpotsPresent { get; set; }
    public bool SolidFormationsPresent { get; set; }
    public bool LiquidContentFormationsPresent { get; set; }
    public bool SkinLesionsPresent { get; set; }
    public bool SequelaeOrScarsPresent { get; set; }
    public bool FacialHairAlterationsPresent { get; set; }
    public bool KeratinizationAlterationsPresent { get; set; }
    public ESkinClassification SkinClassification { get; set; }
    public ESkinThicknessClassification SkinThicknessClassification { get; set; }
    public EOilinessClassification OilinessClassification { get; set; }
    public ESensitivityClassification SensitivityClassification { get; set; }
    public string Notes { get; set; } = string.Empty;
    public MeasurementsDto Measurement { get; set; } = new();
    public FemaleHabitsDto FemaleHabits { get; set; } = new();
    public Habits Habits { get; set; } = new();
    public PatientHistoryDto PatientHistory { get; set; } = new();
}
