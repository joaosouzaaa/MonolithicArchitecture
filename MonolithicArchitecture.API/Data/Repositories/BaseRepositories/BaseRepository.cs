using Microsoft.EntityFrameworkCore;
using MonolithicArchitecture.API.Data.DatabaseContexts;

namespace MonolithicArchitecture.API.Data.Repositories.BaseRepositories;

public abstract class BaseRepository<TEntity> : IDisposable
    where TEntity : class
{
    protected readonly AppDbContext _dbContext;
    protected DbSet<TEntity> DbContextSet => _dbContext.Set<TEntity>();

    protected BaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Dispose()
    {
        _dbContext.Dispose();

        GC.SuppressFinalize(this);
    }

    protected async Task<bool> SaveChangesAsync() =>
        await _dbContext.SaveChangesAsync() > 0;
}
