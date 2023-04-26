using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZdravotniSystem.DB.Entity;
using ZdravotniSystem.DTO;
using ZdravotniSystem.Model;
using ZdravotniSystem.Service;

namespace ZdravotniSystem.Controllers
{
    [Route("api/appointment")]
    [ApiController, Authorize]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("list")]
        public IEnumerable<AppointmentDto> Get()
        {
            return _appointmentService.FindAll()
                                      .Select(
                                          appointment => new AppointmentDto()
                                              .FromAppointment(appointment)
                                          );
        }

        [HttpPost("create")]
        public void Post([FromBody] AppointmentModel value)
        {
            _appointmentService.Create(value);
        }

        [HttpDelete("delete")]
        public void Delete(int id)
        {
            _appointmentService.Delete(id);
        }
    }
}
