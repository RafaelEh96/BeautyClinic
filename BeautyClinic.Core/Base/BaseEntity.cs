using BeautyClinic.Core.Models.Clinic;

namespace BeautyClinic.Core.Base;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public bool IsSaved => Id > 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public string UpdatedBy { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public long ClinicId { get; set; }
    public Clinic? Clinic { get; set; }
}
