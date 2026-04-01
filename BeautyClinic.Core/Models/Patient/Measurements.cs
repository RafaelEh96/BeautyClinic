using BeautyClinic.Core.Base;
using BeautyClinic.Core.Models.Consulation;
using BeautyClinic.Core.Models.Person;

namespace BeautyClinic.Core.Models.Patient;

public class Measurements : BaseEntity
{
    public double Weight { get; set; }
    public double Height { get; set; }
    public double Bust { get; set; }
    public double LeftArm { get; set; }
    public double RightArm { get; set; }
    public double UpperAbdomen { get; set; }
    public double Hip { get; set; }
    public double LeftThigh { get; set; }
    public double RightThigh { get; set; }
    public double LeftCalf { get; set; }
    public double RightCalf { get; set; }
    public DateTime MeasurementDate { get; set; }
    public Guid ClientId { get; set; }
    public Individual Client { get; set; } = new();
    public List<BodyAnamnesis> BodyAnamneses { get; set; } = [];
}
