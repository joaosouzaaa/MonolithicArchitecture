using FluentValidation;
using MonolithicArchitecture.API.DataTransferObjects.Speciality;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Enums;
using MonolithicArchitecture.API.Extensions;
using MonolithicArchitecture.API.Interfaces.Mappers;
using MonolithicArchitecture.API.Interfaces.Repositories;
using MonolithicArchitecture.API.Interfaces.Services;
using MonolithicArchitecture.API.Interfaces.Settings;
using MonolithicArchitecture.API.Services.BaseServices;

namespace MonolithicArchitecture.API.Services;
public sealed class SpecialityService : BaseService<Speciality>, ISpecialityService, ISpecialityServiceFacade
{
    private readonly ISpecialityRepository _specialityRepository;
    private readonly ISpecialityMapper _specialityMapper;

    public SpecialityService(ISpecialityRepository specialityRepository, ISpecialityMapper specialityMapper,
                             INotificationHandler notificationHandler, IValidator<Speciality> validator)
                             : base(notificationHandler, validator)
    {
        _specialityRepository = specialityRepository;
        _specialityMapper = specialityMapper;
    }

    public async Task<bool> AddAsync(SpecialitySave specialitySave)
    {
        var speciality = _specialityMapper.SaveToDomain(specialitySave);

        if (!await ValidateAsync(speciality))
            return false;

        return await _specialityRepository.AddAsync(speciality);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!await _specialityRepository.ExistsAsync(id))
        {
            _notificationHandler.AddNotification(nameof(EMessage.NotFound), EMessage.NotFound.Description().FormatTo("Speciality"));

            return false;
        }

        return await _specialityRepository.DeleteAsync(id);
    }

    public async Task<List<SpecialityResponse>> GetAllAsync()
    {
        var specialityList = await _specialityRepository.GetAllAsync();

        return _specialityMapper.DomainLisToResponseList(specialityList);
    }

    public Task<Speciality?> GetByIdReturnsDomainObjectAsync(int id) =>
        _specialityRepository.GetByIdAsync(id);
}
