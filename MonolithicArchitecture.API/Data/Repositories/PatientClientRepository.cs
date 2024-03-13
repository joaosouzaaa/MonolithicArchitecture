using Microsoft.EntityFrameworkCore;
using MonolithicArchitecture.API.Data.DatabaseContexts;
using MonolithicArchitecture.API.Data.Repositories.BaseRepositories;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Repositories;

namespace MonolithicArchitecture.API.Data.Repositories;
public sealed class PatientClientRepository : BaseRepository<PatientClient>, IPatientClientRepository, IPatientClientRepositoryFacade
{
    public PatientClientRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AddAsync(PatientClient patientClient)
    {
        await DbContextSet.AddAsync(patientClient);

        return await SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(PatientClient patientClient)
    {
        _dbContext.Entry(patientClient.ContactInfo).State = EntityState.Modified;
        _dbContext.Entry(patientClient).State = EntityState.Modified;

        return await SaveChangesAsync();
    }

    public Task<PatientClient?> GetByIdAsync(int id, bool asNoTracking)
    {
        var query = (IQueryable<PatientClient>)DbContextSet;

        if (asNoTracking)
            query = DbContextSet.AsNoTracking();

        return query.Include(p => p.ContactInfo).FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<bool> ExistsAsync(int id) =>
        DbContextSet.AsNoTracking().AnyAsync(p => p.Id == id);

    public Task<string?> GetEmailByIdAsync(int id) =>
        DbContextSet.AsNoTracking().Where(p => p.Id == id).Select(p => p.ContactInfo.Email).FirstOrDefaultAsync();
}
