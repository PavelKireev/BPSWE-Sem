using ZdravotniSystem.DB.Entity;
using ZdravotniSystem.Model;

namespace ZdravotniSystem.DTO;

public class AppointmentDto
{
    public int Id { get; set; }
    public string DoctorEmail { get; set; }
    public string PatientEmail { get; set; }
    public string DateTime { get; set; }

    public AppointmentDto FromAppointment(Appointment appointment)
    {
        return new AppointmentDto
        {
            Id = appointment.Id,
            DoctorEmail = appointment.Doctor.Email,
            PatientEmail = appointment.Patient.Email,
            DateTime = appointment.Time
        };
    }
}