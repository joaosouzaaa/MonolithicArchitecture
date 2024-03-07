using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Repositories;
public interface IScheduleRepository
{
    Task<bool> AddAsync(Schedule schedule);
}
