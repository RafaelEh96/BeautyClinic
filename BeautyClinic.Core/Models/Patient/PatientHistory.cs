using BeautyClinic.Core.Base;
using BeautyClinic.Core.Models.Person;

namespace BeautyClinic.Core.Models.Patient;

public class PatientHistory : BaseEntity
{
    public string PreviousTreatments { get; set; } = string.Empty;
    public string Allergies { get; set; } = string.Empty;
    public string OncologicalTreatments { get; set; } = string.Empty;
    public bool Hypertension { get; set; }
    public bool HeartProblem { get; set; }
    public bool Pacemaker { get; set; }
    public bool MetalProstheses { get; set; }
    public bool DentalProstheses { get; set; }
    public bool Epilepsy { get; set; }
    public bool UnderMedicalTreatment { get; set; }
    public Guid ClientId { get; set; }
    public Individual Client { get; set; } = new();
}
