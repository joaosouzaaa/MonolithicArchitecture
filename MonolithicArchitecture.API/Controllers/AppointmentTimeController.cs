using Microsoft.AspNetCore.Mvc;
using MonolithicArchitecture.API.DataTransferObjects.AppointmentTime;
using MonolithicArchitecture.API.Interfaces.Services;
using MonolithicArchitecture.API.Settings.NotificationSettings;

namespace MonolithicArchitecture.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class AppointmentTimeController(IAppointmentTimeService appointmentTimeService) : ControllerBase
{
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> AddAsync([FromBody] AppointmentTimeSave appointmentTimeSave) =>
        appointmentTimeService.AddAsync(appointmentTimeSave);
}
