using MonolithicArchitecture.API.DataTransferObjects.DoctorAttendant;
using MonolithicArchitecture.API.Settings.PaginationSettings;

namespace MonolithicArchitecture.API.Interfaces.Services;
public interface IDoctorAttendantService
{
    Task<bool> AddAsync(DoctorAttendantSave doctorAttendantSave);
    Task<bool> UpdateAsync(DoctorAttendantUpdate doctorAttendantUpdate);
    Task<PageList<DoctorAttendantResponse>> GetAllFilteredAndPaginatedAsync(DoctorGetAllFilterRequest filterRequest);
    Task<DoctorAttendantResponse?> GetByIdAsync(int id);
}
