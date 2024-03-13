using MonolithicArchitecture.API.DataTransferObjects.Certification;
using MonolithicArchitecture.API.Entities;
using MonolithicArchitecture.API.Interfaces.Mappers;

namespace MonolithicArchitecture.API.Mappers;
public sealed class CertificationMapper : ICertificationMapper
{
    public Certification RequestToDomainCreate(CertificationRequest certificationRequest) =>
        new()
        {
            LicenseNumber = certificationRequest.LicenseNumber
        };

    public void RequestToDomainUpdate(CertificationRequest certificationRequest, Certification certification) =>
        certification.LicenseNumber = certificationRequest.LicenseNumber;

    public CertificationResponse DomainToResponse(Certification certification) =>
        new()
        {
            Id = certification.Id,
            LicenseNumber = certification.LicenseNumber
        };
}
