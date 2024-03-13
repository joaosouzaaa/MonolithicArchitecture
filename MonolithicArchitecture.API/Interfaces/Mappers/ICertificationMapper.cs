using MonolithicArchitecture.API.DataTransferObjects.Certification;
using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Mappers;
public interface ICertificationMapper
{
    Certification RequestToDomainCreate(CertificationRequest certificationRequest);
    void RequestToDomainUpdate(CertificationRequest certificationRequest, Certification certification);
    CertificationResponse DomainToResponse(Certification certification);
}
