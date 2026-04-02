using BeautyClinic.Core.DTOs.Consultation;
using BeautyClinic.Core.Enums;

namespace BeautyClinic.Core.Models.Consulation;

public class FacialAnamnesis : Anamnesis
{
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
}
