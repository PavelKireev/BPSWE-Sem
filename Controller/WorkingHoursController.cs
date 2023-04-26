using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZdravotniSystem.DB.Entity;
using ZdravotniSystem.DB.Repository;
using ZdravotniSystem.Model;
using ZdravotniSystem.Service;
using ZdravotniSystem.Util;

namespace ZdravotniSystem.Controller
{
    [Route("api/working-hours")]
    [ApiController, Authorize]
    public class WorkingHoursController : ControllerBase
    {
        private readonly IWorkingHoursService _workingHoursService;
        private readonly IUserRepository _userRepository; 

        public WorkingHoursController(
            IWorkingHoursService workingHoursService, 
            IUserRepository userRepository
        ) {
            _workingHoursService = workingHoursService;
            _userRepository = userRepository;
        }

        [HttpGet("available")]
        public IEnumerable<string> Available(string doctorEmail)
        {
            return DateTimeUtil.GenerateAppointmentTimeList(
                        _workingHoursService
                            .GetWorkingHoursByDoctorId(_userRepository.GetOneByEmail(doctorEmail).Id)
                        ).Select(dateTime => dateTime.ToString(CultureInfo.InvariantCulture));
        }

        [HttpGet("list")]
        public List<WorkingHours> Get(
            int doctorId
        ) {
            return _workingHoursService.GetWorkingHoursByDoctorId(doctorId);
        }

        [HttpPost("create")]
        public List<WorkingHours> Post([FromBody] WorkingHours value, int doctorId)
        {
            value.DoctorId = doctorId;
            _workingHoursService.Create(value);
            return _workingHoursService.GetWorkingHoursByDoctorId(doctorId);
        }

        [HttpDelete("delete")]
        public List<WorkingHours> Delete(int id, int doctorId)
        {
            _workingHoursService.Delete(id);
            return _workingHoursService.GetWorkingHoursByDoctorId(doctorId);
        }
    }
}
