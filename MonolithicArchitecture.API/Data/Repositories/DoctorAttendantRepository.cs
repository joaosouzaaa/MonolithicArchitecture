using Microsoft.EntityFrameworkCore;
using MonolithicArchitecture.API.Arguments;
using MonolithicArchitecture.API.Data.DatabaseContexts;
using MonolithicArchitecture.API.Data.Repositories.BaseRepositories;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Repositories;
using MonolithicArchitecture.API.Settings.PaginationSettings;

namespace MonolithicArchitecture.API.Data.Repositories;
public sealed class DoctorAttendantRepository : BaseRepository<DoctorAttendant>, IDoctorAttendantRepository
{
    public DoctorAttendantRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AddAsync(DoctorAttendant doctorAttendant)
    {
        await DbContextSet.AddAsync(doctorAttendant);

        return await SaveChangesAsync();
    }

    public Task<bool> UpdateAsync(DoctorAttendant doctorAttendant)
    {
        _dbContext.Entry(doctorAttendant.Certification).State = EntityState.Modified;
        _dbContext.Entry(doctorAttendant).State = EntityState.Modified;

        return SaveChangesAsync();
    }

    public Task<PageList<DoctorAttendant>> GetAllFilteredAndPaginatedAsync(DoctorGetAllFilterArgument filter) =>
        DbContextSet.Include(d => d.Certification)
                    .Include(d => d.Specialities)
                    .Include(d => d.Schedules)
                    .Where(d => d.Specialities.Any(s => filter.SpecialityIds.Contains(s.Id)))
                    .Where(d => filter.InitialTime == null
                    || d.Schedules.Any(s => s.Time >= filter.InitialTime))
                    .Where(d => filter.FinalTime == null
                    || d.Schedules.Any(s => s.Time <= filter.FinalTime))
                    .PaginateAsync(filter);

    public Task<DoctorAttendant?> GetByIdAsync(int id, bool asNoTracking)
    {
        var query = (IQueryable<DoctorAttendant>)DbContextSet;

        if (asNoTracking)
            query = DbContextSet.AsNoTracking();

        return DbContextSet.Include(d => d.Certification)
                           .Include(d => d.Specialities)
                           .Include(d => d.Schedules)
                           .FirstOrDefaultAsync(d => d.Id == id);
    }

    public Task<bool> ExistsAsync(int id) =>
        DbContextSet.AsNoTracking().AnyAsync(d => d.Id == id);
}
