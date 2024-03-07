using Microsoft.EntityFrameworkCore;
using MonolithicArchitecture.API.Data.DatabaseContexts;
using MonolithicArchitecture.API.Data.Repositories.BaseRepositories;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Repositories;

namespace MonolithicArchitecture.API.Data.Repositories;
public sealed class SpecialityRepository(AppDbContext dbContext) : BaseRepository<Speciality>(dbContext), ISpecialityRepository
{
    public async Task<bool> AddAsync(Speciality speciality)
    {
        await DbContextSet.AddAsync(speciality);

        return await SaveChangesAsync();
    }

    public Task<bool> ExistsAsync(int id) =>
        DbContextSet.AsNoTracking().AnyAsync(s => s.Id == id);

    public async Task<bool> DeleteAsync(int id)
    {
        var speciality = await DbContextSet.FirstOrDefaultAsync(s => s.Id == id);

        DbContextSet.Remove(speciality!);

        return await SaveChangesAsync();
    }

    public Task<List<Speciality>> GetAllAsync() =>
        DbContextSet.AsNoTracking().ToListAsync();

    public Task<Speciality?> GetByIdAsync(int id) =>
        DbContextSet.FirstOrDefaultAsync(s => s.Id == id);
}
