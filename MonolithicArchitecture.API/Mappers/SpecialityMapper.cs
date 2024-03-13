using MonolithicArchitecture.API.DataTransferObjects.Speciality;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Mappers;

namespace MonolithicArchitecture.API.Mappers;
public sealed class SpecialityMapper : ISpecialityMapper
{
    public Speciality SaveToDomain(SpecialitySave specialitySave) =>
        new()
        {
            Name = specialitySave.Name
        };

    public List<SpecialityResponse> DomainLisToResponseList(List<Speciality> specialityList) =>
        specialityList.Select(DomainToResponse).ToList();

    private SpecialityResponse DomainToResponse(Speciality speciality) =>
        new()
        {
            Id = speciality.Id,
            Name = speciality.Name
        };
}
