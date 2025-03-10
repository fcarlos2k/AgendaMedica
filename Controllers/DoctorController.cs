using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Controllers;

[Route("[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly IDoctorDapperRepository _doctorRepository;

    public DoctorController(IDoctorDapperRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
    {
        var doctors = await _doctorRepository.GetDoctorsAsync();
        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Doctor>> GetDoctorById(int id)
    {
        var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
        if (doctor == null)
        {
            return NotFound();
        }
        return Ok(doctor);
    }

    [HttpPost]
    public async Task<ActionResult<Doctor>> AddDoctor(Doctor doctor)
    {
        if (doctor == null)
        {
            return BadRequest();
        }

        var id = await _doctorRepository.AddPatientAsync(doctor);
        doctor.Id = id;
        return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctor(int id, Doctor doctor)
    {
        if (id != doctor.Id)
        {
            return BadRequest();
        }

        var existingDoctor = await _doctorRepository.GetDoctorByIdAsync(id);
        if (existingDoctor == null)
        {
            return NotFound();
        }

        await _doctorRepository.UpdatePatientAsync(doctor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
        if (doctor == null)
        {
            return NotFound();
        }

        await _doctorRepository.DeletePatientAsync(id);
        return NoContent();
    }
}