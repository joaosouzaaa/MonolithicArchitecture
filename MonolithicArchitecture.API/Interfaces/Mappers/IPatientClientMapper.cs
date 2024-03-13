using MonolithicArchitecture.API.DataTransferObjects.PatientClient;
using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Mappers;
public interface IPatientClientMapper
{
    PatientClient SaveToDomain(PatientClientSave patientClientSave);
    void UpdateToDomain(PatientClientUpdate patientClientUpdate, PatientClient patientClient);
    PatientClientResponse DomainToResponse(PatientClient patientClient);
}
