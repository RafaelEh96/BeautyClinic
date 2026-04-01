using BeautyClinic.Core.Models.Clinic;

namespace BeautyClinic.Core.Base;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public bool IsSaved => Id != Guid.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public string UpdatedBy { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public Guid ClinicId { get; set; }
    public Clinic? Clinic { get; set; }
}
