using Microsoft.AspNetCore.Mvc;
using MonolithicArchitecture.API.DataTransferObjects.DoctorAttendant;
using MonolithicArchitecture.API.Interfaces.Services;
using MonolithicArchitecture.API.Settings.NotificationSettings;
using MonolithicArchitecture.API.Settings.PaginationSettings;

namespace MonolithicArchitecture.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class DoctorAttendantController(IDoctorAttendantService doctorAttendantService) : ControllerBase
{
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> AddAsync([FromBody] DoctorAttendantSave doctorAttendantSave) =>
        doctorAttendantService.AddAsync(doctorAttendantSave);

    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> UpdateAsync([FromBody] DoctorAttendantUpdate doctorAttendantUpdate) =>
        doctorAttendantService.UpdateAsync(doctorAttendantUpdate);

    [HttpGet("get-all-filtered")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PageList<DoctorAttendantResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<PageList<DoctorAttendantResponse>> GetAllFilteredAndPaginatedAsync([FromQuery] DoctorGetAllFilterRequest filterRequest) =>
        doctorAttendantService.GetAllFilteredAndPaginatedAsync(filterRequest);

    [HttpGet("get-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<DoctorAttendantResponse?> GetByIdAsync([FromQuery] int id) =>
        doctorAttendantService.GetByIdAsync(id);
}
