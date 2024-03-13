using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Mappers;
using MonolithicArchitecture.API.Interfaces.Repositories;
using MonolithicArchitecture.API.Interfaces.Services;

namespace MonolithicArchitecture.API.Services;
public sealed class ScheduleService(IScheduleRepository scheduleRepository, IScheduleMapper scheduleMapper) : IScheduleService
{
    public async Task AddAsync(AppointmentTime appointmentTime)
    {
        var schedule = scheduleMapper.AppointmentTimeToDomain(appointmentTime);

        await scheduleRepository.AddAsync(schedule);
    }
}
