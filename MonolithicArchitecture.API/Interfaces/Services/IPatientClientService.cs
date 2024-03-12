using MonolithicArchitecture.API.DataTransferObjects.PatientClient;

namespace MonolithicArchitecture.API.Interfaces.Services;
public interface IPatientClientService
{
    Task<bool> AddAsync(PatientClientSave patientClientSave);
    Task<bool> UpdateAsync(PatientClientUpdate patientClientUpdate);
    Task<PatientClientResponse?> GetByIdAsync(int id);
}
