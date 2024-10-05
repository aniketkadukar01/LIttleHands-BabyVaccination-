using LittleHands.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LittleHands.Data.Config
{
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.AppointmentDate)
                .IsRequired()
                .HasColumnType(typeName: "date");

            builder.Property(a => a.AppointmentTime) .IsRequired()
                .HasColumnType(typeName: "time");

            builder.Property(a =>a.Status)
                .IsRequired();

            builder.HasOne(a => a.Children)
                .WithMany()
                .HasForeignKey(a => a.ChildrenID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(a => a.VaccineType)
                .WithMany(v => v.Appointments)
                .HasForeignKey(a => a.VaccineId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
