using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MonolithicArchitecture.API.Entities;

namespace Doctor.Infrasctructure.EntitiesMapping;
public sealed class ScheduleMapping : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable("Schedules");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Time)
            .IsRequired(true)
            .HasColumnName("time")
            .HasColumnType("timestamp without time zone");
    }
}
