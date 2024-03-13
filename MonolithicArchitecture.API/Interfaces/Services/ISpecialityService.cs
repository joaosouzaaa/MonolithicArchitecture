using MonolithicArchitecture.API.DataTransferObjects.Speciality;

namespace MonolithicArchitecture.API.Interfaces.Services;
public interface ISpecialityService
{
    Task<bool> AddAsync(SpecialitySave specialitySave);
    Task<bool> DeleteAsync(int id);
    Task<List<SpecialityResponse>> GetAllAsync();
}
