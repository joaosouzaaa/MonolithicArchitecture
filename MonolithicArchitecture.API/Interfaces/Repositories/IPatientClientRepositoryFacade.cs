namespace MonolithicArchitecture.API.Interfaces.Repositories;
public interface IPatientClientRepositoryFacade
{
    Task<string?> GetEmailByIdAsync(int id);
}
