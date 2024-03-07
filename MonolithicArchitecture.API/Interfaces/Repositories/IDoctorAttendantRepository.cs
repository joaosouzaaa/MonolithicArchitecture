using MonolithicArchitecture.API.Arguments;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Settings.PaginationSettings;

namespace MonolithicArchitecture.API.Interfaces.Repositories;
public interface IDoctorAttendantRepository
{
    Task<bool> AddAsync(DoctorAttendant doctorAttendant);
    Task<bool> UpdateAsync(DoctorAttendant doctorAttendant);
    Task<PageList<DoctorAttendant>> GetAllFilteredAndPaginatedAsync(DoctorGetAllFilterArgument filter);
    Task<DoctorAttendant?> GetByIdAsync(int id, bool asNoTracking);
    Task<bool> ExistsAsync(int id);
}
