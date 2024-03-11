using MonolithicArchitecture.API.DataTransferObjects.ContactInfo;

namespace MonolithicArchitecture.API.DataTransferObjects.PatientClient;
public sealed record PatientClientSave(string Name, 
                                       string Address,
                                       ContactInfoRequest ContactInfo);
