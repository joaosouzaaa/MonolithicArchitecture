namespace MonolithicArchitecture.API.DataTransferObjects.AppointmentTime;
public sealed record AppointmentTimeSave(DateTime Time,
                                         int DoctorAttendantId,
                                         int PatientClientId);
