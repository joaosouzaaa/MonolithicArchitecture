using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Data.EntitiesMapping;
public sealed class AppointmentTimeMapping : IEntityTypeConfiguration<AppointmentTime>
{
    public void Configure(EntityTypeBuilder<AppointmentTime> builder)
    {
        builder.ToTable("AppointmentsTime");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Time)
            .IsRequired(true)
            .HasColumnName("time")
            .HasColumnType("timestamp without time zone");

        builder.HasOne(s => s.DoctorAttendant)
            .WithMany(d => d.Appointments)
            .HasForeignKey(s => s.DoctorAttendantId)
            .HasConstraintName("FK_AppointmentTime_DoctorAttendant")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.PatientClient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(s => s.PatientClientId)
            .HasConstraintName("FK_AppointmentTime_PatientClient")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
