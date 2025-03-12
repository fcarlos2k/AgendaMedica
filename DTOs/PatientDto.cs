namespace AgendaMedica.DTOs;

public class PatientDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Cpf { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}
