using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientDapperRepository _patientRepository;

    public PatientController(IPatientDapperRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
    {
        var patients = await _patientRepository.GetPatientsAsync();
        return Ok(patients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatientById(int id)
    {
        var patient = await _patientRepository.GetPatientByIdAsync(id);
        if (patient == null)
        {
            return NotFound();
        }
        return Ok(patient);
    }

    [HttpPost]
    public async Task<ActionResult<Patient>> AddPatient(Patient patient)
    {
        if (patient == null)
        {
            return BadRequest();
        }

        var id = await _patientRepository.AddPatientAsync(patient);
        patient.Id = id;
        return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(int id, Patient patient)
    {
        if (id != patient.Id)
        {
            return BadRequest();
        }

        var existingPatient = await _patientRepository.GetPatientByIdAsync(id);
        if (existingPatient == null)
        {
            return NotFound();
        }

        await _patientRepository.UpdatePatientAsync(patient);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var patient = await _patientRepository.GetPatientByIdAsync(id);
        if (patient == null)
        {
            return NotFound();
        }

        await _patientRepository.DeletePatientAsync(id);
        return NoContent();
    }
}
