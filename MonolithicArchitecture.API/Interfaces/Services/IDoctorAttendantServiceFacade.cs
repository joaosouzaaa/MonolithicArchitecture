namespace MonolithicArchitecture.API.Interfaces.Services;

public interface IDoctorAttendantServiceFacade
{
    Task<bool> ExistsAsync(int id);
}
