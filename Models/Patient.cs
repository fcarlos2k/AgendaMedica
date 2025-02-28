namespace AgendaMedica.Models;

public class Patient
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Cpf { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}
