using MonolithicArchitecture.API.DataTransferObjects.Speciality;
using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Mappers;
public interface ISpecialityMapper
{
    Speciality SaveToDomain(SpecialitySave specialitySave);
    List<SpecialityResponse> DomainLisToResponseList(List<Speciality> specialityList);
}
