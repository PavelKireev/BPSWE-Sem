using ZdravotniSystem.Controllers;
using ZdravotniSystem.DB.Entity;
using ZdravotniSystem.Model;
using ZdravotniSystem.Repository;

namespace ZdravotniSystem.Service
{
    public interface IAppointmentService
    {
        List<Appointment> FindAll();
        List<Appointment> FindAllByUserIdAndRole(int userId, string role);
        List<Appointment> FindAllByDoctorId(int doctorId);
        void Delete(int id);
        void Create(AppointmentModel model);
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly ILogger<AppointmentService> _logger;
        private readonly IAppointmentRepository _appointmetRepository;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public AppointmentService(
            ILogger<AppointmentService> logger, 
            IAppointmentRepository appointmetRepository,
            IDoctorService doctorService, 
            IPatientService patientService
        ) {
            _logger = logger;
            _appointmetRepository = appointmetRepository;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        public void Create(AppointmentModel model)
        {
            Doctor doctor = _doctorService.GetDoctorByEmail(model.DoctorEmail);
            Patient patient = _patientService.GetPatientByEmail(model.PatientEmail);
            Appointment appointment = new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                Time = model.DateTime
            };
            
            _appointmetRepository.Save(appointment);
        }

        public void Delete(int id)
        {
            _appointmetRepository.Delete(id);
        }

        public List<Appointment> FindAll()
        {
            return _appointmetRepository.FindAll();
        }

        public List<Appointment> FindAllByDoctorId(int doctorId)
        {
            return _appointmetRepository.FindAll();
        }

        public List<Appointment> FindAllByUserIdAndRole(int userId, string role)
        {
            throw new NotImplementedException();
        }
    }

}
