using MonolithicArchitecture.API.DataTransferObjects.Certification;

namespace MonolithicArchitecture.API.DataTransferObjects.DoctorAttendant;
public sealed record DoctorAttendantUpdate(int Id,
                                           string Name,
                                           int ExperienceYears,
                                           DateTime BirthDate,
                                           CertificationRequest Certification,
                                           List<int> SpecialityIds);
