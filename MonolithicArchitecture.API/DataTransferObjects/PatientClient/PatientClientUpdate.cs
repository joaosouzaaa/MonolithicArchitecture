using MonolithicArchitecture.API.DataTransferObjects.ContactInfo;

namespace MonolithicArchitecture.API.DataTransferObjects.PatientClient;
public sealed record PatientClientUpdate(int Id,
                                         string Name,
                                         string Address,
                                         ContactInfoRequest ContactInfo);
