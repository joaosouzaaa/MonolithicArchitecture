using Microsoft.EntityFrameworkCore;
using MonolithicArchitecture.API.Data.DatabaseContexts;
using MonolithicArchitecture.API.Data.Repositories.BaseRepositories;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Repositories;

namespace MonolithicArchitecture.API.Data.Repositories;
public sealed class AppointmentTimeRepository(AppDbContext dbContext) : BaseRepository<AppointmentTime>(dbContext), IAppointmentTimeRepository
{
    public async Task<bool> AddAsync(AppointmentTime appointmentTime)
    {
        await DbContextSet.AddAsync(appointmentTime);

        return await SaveChangesAsync();
    }

    public Task<bool> ExistsByTimeAndDoctorAsync(int doctorAttendantId, DateTime time) =>
        DbContextSet.AnyAsync(a => a.DoctorAttendantId == doctorAttendantId && a.Time == time);
}
