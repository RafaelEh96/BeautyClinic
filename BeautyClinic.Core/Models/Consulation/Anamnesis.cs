using BeautyClinic.Core.Base;
using BeautyClinic.Core.Models.Person;

namespace BeautyClinic.Core.Models.Consulation;

public class Anamnesis : BaseEntity
{
    public Individual Client { get; set; } = new();
    public Guid ClientId { get; set; }
}
