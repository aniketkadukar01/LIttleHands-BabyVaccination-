using LittleHands.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LittleHands.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.FirstName).IsRequired();

            builder.Property(u => u.LastName).IsRequired();

            builder.Property(u => u.ContactNumber).IsRequired();
            builder.Property(u => u.ContactNumber).HasMaxLength(10);
            builder.HasIndex(u => u.ContactNumber).IsUnique();

            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).IsRequired();

            builder.Property(u => u.Password).IsRequired();

            builder.Property(u => u.Role).IsRequired();

            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    ContactNumber = "1234567890",
                    Email = "john.doe@example.com",
                    Password = "password123",
                    Role = Role.ADMIN
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    ContactNumber = "0987654321",
                    Email = "jane.smith@example.com",
                    Password = "password456",
                    Role = Role.USER
                });
        }
    }
}
