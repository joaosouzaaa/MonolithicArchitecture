using FluentValidation;
using MonolithicArchitecture.API.DataTransferObjects.PatientClient;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Enums;
using MonolithicArchitecture.API.Extensions;
using MonolithicArchitecture.API.Interfaces.Mappers;
using MonolithicArchitecture.API.Interfaces.Repositories;
using MonolithicArchitecture.API.Interfaces.Services;
using MonolithicArchitecture.API.Interfaces.Settings;
using MonolithicArchitecture.API.Services.BaseServices;

namespace MonolithicArchitecture.API.Services;
public sealed class PatientClientService : BaseService<PatientClient>, IPatientClientService
{
    private readonly IPatientClientRepository _patientClientRepository;
    private readonly IPatientClientMapper _patientClientMapper;

    public PatientClientService(IPatientClientRepository patientClientRepository, IPatientClientMapper patientClientMapper, 
                                INotificationHandler notificationHandler, IValidator<PatientClient> validator) 
                                : base(notificationHandler, validator)
    {
        _patientClientRepository = patientClientRepository;
        _patientClientMapper = patientClientMapper;
    }

    public async Task<bool> AddAsync(PatientClientSave patientClientSave)
    {
        var patientClient = _patientClientMapper.SaveToDomain(patientClientSave);

        if (!await ValidateAsync(patientClient))
            return false;

        return await _patientClientRepository.AddAsync(patientClient);
    }

    public async Task<bool> UpdateAsync(PatientClientUpdate patientClientUpdate)
    {
        var patientClient = await _patientClientRepository.GetByIdAsync(patientClientUpdate.Id, false);

        if (patientClient is null)
        {
            _notificationHandler.AddNotification(nameof(EMessage.NotFound), EMessage.NotFound.Description().FormatTo("Patient"));

            return false;
        }

        _patientClientMapper.UpdateToDomain(patientClientUpdate, patientClient);

        if (!await ValidateAsync(patientClient))
            return false;

        return await _patientClientRepository.UpdateAsync(patientClient);
    }

    public async Task<PatientClientResponse?> GetByIdAsync(int id)
    {
        var patientClient = await _patientClientRepository.GetByIdAsync(id, true);

        if (patientClient is null)
            return null;

        return _patientClientMapper.DomainToResponse(patientClient);
    }
}
