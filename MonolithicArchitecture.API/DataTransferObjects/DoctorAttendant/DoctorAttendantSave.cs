using MonolithicArchitecture.API.DataTransferObjects.Certification;

namespace MonolithicArchitecture.API.DataTransferObjects.DoctorAttendant;
public sealed record DoctorAttendantSave(string Name,
                                         int ExperienceYears,
                                         DateTime BirthDate,
                                         CertificationRequest Certification,
                                         List<int> SpecialityIds);
