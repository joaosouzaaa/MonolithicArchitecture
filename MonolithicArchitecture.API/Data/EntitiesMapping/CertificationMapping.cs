using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MonolithicArchitecture.API.Entities;

namespace Doctor.Infrasctructure.EntitiesMapping;
public sealed class CertificationMapping : IEntityTypeConfiguration<Certification>
{
    public void Configure(EntityTypeBuilder<Certification> builder)
    {
        builder.ToTable("Certifications");
        
        builder.HasKey(c => c.Id);

        builder.Property(c => c.LicenseNumber)
            .IsRequired(true)
            .HasColumnName("license_number")
            .HasColumnType("varchar(20)");
    }
}
