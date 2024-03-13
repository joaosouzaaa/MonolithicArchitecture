using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Services;
public interface ISpecialityServiceFacade
{
    Task<Speciality?> GetByIdReturnsDomainObjectAsync(int id);
}
