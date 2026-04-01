using BeautyClinic.Core.Base;
using BeautyClinic.Core.Enums;
using BeautyClinic.Core.Models.Person;

namespace BeautyClinic.Core.Models.Patient;

public class Habits : BaseEntity
{
    public bool BalencedDiet { get; set; }
    public bool RegularBowels { get; set; }
    public bool RegularSleep { get; set; }
    public bool PracticesPhysicalActivities { get; set; }
    public int? PhysicalActivityDaysPerWeek { get; set; }
    public bool Smoker { get; set; }
    public bool ConsumesAlcoholicBeverage { get; set; }
    public bool UseAcidOnSkin { get; set; }
    public EAlcoholConsumptionFrequency AlcoholConsumptionFrequency { get; set; }
    public string AcidsUsed { get; set; } = string.Empty;
    public bool UsesDailySunscreen { get; set; }
    public Guid ClientId { get; set; }
    public Individual Client { get; set; } = new();
}
