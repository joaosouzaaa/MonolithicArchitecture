using FluentValidation;
using MonolithicArchitecture.API.DataTransferObjects.AppointmentTime;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Enums;
using MonolithicArchitecture.API.Extensions;
using MonolithicArchitecture.API.Interfaces.Mappers;
using MonolithicArchitecture.API.Interfaces.Repositories;
using MonolithicArchitecture.API.Interfaces.Services;
using MonolithicArchitecture.API.Interfaces.Settings;
using MonolithicArchitecture.API.Services.BaseServices;

namespace MonolithicArchitecture.API.Services;
public sealed class AppointmentTimeService : BaseService<AppointmentTime>, IAppointmentTimeService
{
    private readonly IAppointmentTimeRepository _appointmentTimeRepository;
    private readonly IAppointmentTimeMapper _appointmentTimeMapper;
    private readonly IDoctorAttendantServiceFacade _doctorAttendantServiceFacade;
    private readonly IPatientClientServiceFacade _patientClientServiceFacade;
    private readonly IScheduleService _scheduleService;
    private readonly IEmailService _emailService;

    public AppointmentTimeService(IAppointmentTimeRepository appointmentTimeRepository, IAppointmentTimeMapper appointmentTimeMapper,
                                  IDoctorAttendantServiceFacade doctorAttendantServiceFacade, IPatientClientServiceFacade patientClientServiceFacade,
                                  IScheduleService scheduleService, IEmailService emailService,
                                  INotificationHandler notificationHandler, IValidator<AppointmentTime> validator)
                                  : base(notificationHandler, validator)
    {
        _appointmentTimeRepository = appointmentTimeRepository;
        _appointmentTimeMapper = appointmentTimeMapper;
        _doctorAttendantServiceFacade = doctorAttendantServiceFacade;
        _patientClientServiceFacade = patientClientServiceFacade;
        _scheduleService = scheduleService;
        _emailService = emailService;
    }

    public async Task<bool> AddAsync(AppointmentTimeSave appointmentTimeSave)
    {
        if (!await EntitiesExistsAsync(appointmentTimeSave))
            return false;

        if (await _appointmentTimeRepository.ExistsByTimeAndDoctorAsync(appointmentTimeSave.DoctorAttendantId, appointmentTimeSave.Time))
        {
            _notificationHandler.AddNotification(nameof(EMessage.Exists), EMessage.Exists.Description().FormatTo("Time"));

            return false;
        }

        var appointmentTime = _appointmentTimeMapper.SaveToDomain(appointmentTimeSave);

        if (!await ValidateAsync(appointmentTime))
            return false;

        var addResult = await _appointmentTimeRepository.AddAsync(appointmentTime);

        await _scheduleService.AddAsync(appointmentTime);
        await _emailService.SendAppointmentEmailAsync(appointmentTime);

        return addResult;
    }

    private async Task<bool> EntitiesExistsAsync(AppointmentTimeSave appointmentTimeSave)
    {
        if (!await _doctorAttendantServiceFacade.ExistsAsync(appointmentTimeSave.DoctorAttendantId))
        {
            _notificationHandler.AddNotification(nameof(EMessage.NotFound), EMessage.NotFound.Description().FormatTo("Doctor"));

            return false;
        }

        if (!await _patientClientServiceFacade.ExistsAsync(appointmentTimeSave.PatientClientId))
        {
            _notificationHandler.AddNotification(nameof(EMessage.NotFound), EMessage.NotFound.Description().FormatTo("Patient"));

            return false;
        }

        return true;
    }
}
