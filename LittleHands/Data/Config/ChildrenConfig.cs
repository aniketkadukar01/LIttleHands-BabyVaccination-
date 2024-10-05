using LittleHands.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LittleHands.Data.Config
{
    public class ChildrenConfig : IEntityTypeConfiguration<Children>
    {
        public void Configure(EntityTypeBuilder<Children> builder)
        {
            builder.ToTable("Childrens");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.DateOfBirth)
                .IsRequired()
                .HasColumnType(typeName : "date");

            builder.Property(c => c.BloodType)
                .IsRequired();

            builder.Property(c => c.Gender)
                .IsRequired ();

            builder.HasOne(c => c.Parent)
                .WithMany()
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

        }
    }
}
