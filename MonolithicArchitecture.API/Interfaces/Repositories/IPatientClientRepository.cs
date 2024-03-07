using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Repositories;
public interface IPatientClientRepository
{
    Task<bool> AddAsync(PatientClient patientClient);
    Task<bool> UpdateAsync(PatientClient patientClient);
    Task<PatientClient?> GetByIdAsync(int id, bool asNoTracking);
    Task<bool> ExistsAsync(int id);
}
