using LittleHands.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LittleHands.Data.Config
{
    public class VaccineTypeConfig : IEntityTypeConfiguration<VaccineType>
    {
        public void Configure(EntityTypeBuilder<VaccineType> builder)
        {
            builder.ToTable("VaccineTypes");

            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id).ValueGeneratedOnAdd();

            builder.Property(v => v.VaccineName)
                .IsRequired();

            builder.Property(v => v.VaccineDescription)
                .IsRequired();

            builder.HasMany(v => v.Appointments)
                .WithOne(a => a.VaccineType)
                .HasForeignKey(a => a.VaccineId)
                .IsRequired();
        }
    }
}
