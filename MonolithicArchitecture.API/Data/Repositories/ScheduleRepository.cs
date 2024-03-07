using MonolithicArchitecture.API.Data.DatabaseContexts;
using MonolithicArchitecture.API.Data.Repositories.BaseRepositories;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Repositories;

namespace MonolithicArchitecture.API.Data.Repositories;
public sealed class ScheduleRepository(AppDbContext dbContext) : BaseRepository<Schedule>(dbContext), IScheduleRepository
{
    public async Task<bool> AddAsync(Schedule schedule)
    {
        await DbContextSet.AddAsync(schedule);

        return await SaveChangesAsync();
    }
}
