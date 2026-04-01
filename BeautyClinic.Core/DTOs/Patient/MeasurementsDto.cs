namespace BeautyClinic.Core.DTOs.Patient;

public class MeasurementsDto
{
    public Guid Id { get; set; }
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
}
