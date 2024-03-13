using MonolithicArchitecture.API.Arguments;
using MonolithicArchitecture.API.DataTransferObjects.DoctorAttendant;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Settings.PaginationSettings;

namespace MonolithicArchitecture.API.Interfaces.Mappers;
public interface IDoctorAttendantMapper
{
    DoctorAttendant SaveToDomain(DoctorAttendantSave doctorAttendantSave);
    void UpdateToDomain(DoctorAttendantUpdate doctorAttendantUpdate, DoctorAttendant doctorAttendant);
    DoctorAttendantResponse DomainToResponse(DoctorAttendant doctorAttendant);
    DoctorGetAllFilterArgument FilterRequestToArgumentDomain(DoctorGetAllFilterRequest doctorGetAllFilterRequest);
    PageList<DoctorAttendantResponse> DomainPageListToResponsePageList(PageList<DoctorAttendant> doctorAttendantPageList);
}
