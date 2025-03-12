using AgendaMedica.Context;
using AgendaMedica.Interfaces;

namespace AgendaMedica.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IDoctorDapperRepository? _doctorDapperRepository;
    private IPatientDapperRepository? _patientDapperRepository;
    private IMedicalConsultationStatusRepository? _medicalConsultationStatusRepository;
    private IMedicalConsultationRepository? _medicalConsultationRepository;


    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IDoctorDapperRepository DoctorDapperRepository
    {
        get
        {
            if (_doctorDapperRepository == null)
            {
                //_doctorDapperRepository = new DoctorDapperRepository(_context);
            }
            return _doctorDapperRepository;
        }
    }

    public IPatientDapperRepository PatientDapperRepository
    {
        get
        {
            if (_patientDapperRepository == null)
            {
                //_patientDapperRepository = new PatientDapperRepository(_context);
            }
            return _patientDapperRepository;
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



    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }


    public void Dispose()
    {
        _context.Dispose();
    }
}
