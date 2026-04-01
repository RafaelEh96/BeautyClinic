using BeautyClinic.Core.Enums;

namespace BeautyClinic.Core.DTOs.Procedure;

public class ProcedureDto
{
    public Guid Id { get; set; }
    public string ProcedureName { get; set; } = string.Empty;
    public int DurationInMinutes { get; set; }
    public string EquipmentUsed { get; set; } = string.Empty;
    public string ConsumedProducts { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public EPaymentMethod PaymentMethod { get; set; }
}