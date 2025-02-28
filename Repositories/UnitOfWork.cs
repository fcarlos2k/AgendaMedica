using AgendaMedica.Context;
using AgendaMedica.Interfaces;

namespace AgendaMedica.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IDoctorRepository? _doctorRepository;
    private IMedicalConsultationStatusRepository? _medicalConsultationStatusRepository;
    private IMedicalConsultationRepository? _medicalConsultationRepository;
    private IPatientRepository? _patientRepository;


    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IDoctorRepository DoctorRepository
    {
        get
        {
            if (_doctorRepository == null)
            {
                _doctorRepository = new DoctorRepository(_context);
            }
            return _doctorRepository;
        }
    }

    public IMedicalConsultationStatusRepository MedicalConsultationStatusRepository
    {
        get
        {
            if (_medicalConsultationStatusRepository == null)
            {
                _medicalConsultationStatusRepository = new MedicalConsultationStatusRepository(_context);
            }
            return _medicalConsultationStatusRepository;
        }
    }


    public IMedicalConsultationRepository MedicalConsultationRepository
    {
        get
        {
            if (_medicalConsultationRepository == null)
            {
                _medicalConsultationRepository = new MedicalConsultationRepository(_context);
            }
            return _medicalConsultationRepository;
        }
    }

    public IPatientRepository PatientRepository
    {
        get
        {
            if (_patientRepository == null)
            {
                _patientRepository = new PatientRepository(_context);
            }
            return _patientRepository;
        }
    }


    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }


    public void Dispose()
    {
        _context.Dispose();
    }
}
