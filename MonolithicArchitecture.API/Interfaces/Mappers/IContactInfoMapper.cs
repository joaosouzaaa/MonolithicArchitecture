using MonolithicArchitecture.API.DataTransferObjects.ContactInfo;
using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Mappers;
public interface IContactInfoMapper
{
    ContactInfo RequestToDomainCreate(ContactInfoRequest contactInfoRequest);
    void RequestToDomainUpdate(ContactInfoRequest contactInfoRequest, ContactInfo contactInfo);
    ContactInfoResponse DomainToResponse(ContactInfo contactInfo);
}
