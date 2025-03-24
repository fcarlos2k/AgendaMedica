using System.Text.Json.Serialization;

namespace AgendaMedica.Models;

public class Doctor
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int MedicalSpecialtyId { get; set; }

    [JsonIgnore]
    public virtual MedicalSpecialty? MedicalSpecialty { get; set; }
}
