namespace MonolithicArchitecture.API.Entities;
public sealed class AppointmentTime
{
    public int Id { get; set; }
    public required DateTime Time { get; set; }

    public required int DoctorAttendantId { get; set; }
    public DoctorAttendant DoctorAttendant { get; set; }
    public required int PatientClientId { get; set; }
    public PatientClient PatientClient { get; set; }
}
