namespace MonolithicArchitecture.API.Interfaces.Services;

public interface IPatientClientServiceFacade
{
    Task<bool> ExistsAsync(int id);
}
