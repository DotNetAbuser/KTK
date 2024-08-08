using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasQueryFilter(u => u.IsDeleted == false);

        builder
            .HasKey(u => u.Id);
        builder
            .Property(u => u.Id)
            .HasConversion(i => i.Value,
                v => new UserId(v))
            .HasColumnName("user_id")
            .IsRequired();

        builder
            .ComplexProperty(u => u.Name, name =>
            {
                name
                    .Property(n => n.Last)
                    .HasColumnName("last_name")
                    .IsRequired();
                name
                    .Property(n => n.First)
                    .HasColumnName("first_name")
                    .IsRequired();
                name
                    .Property(n => n.Middle)
                    .HasColumnName("middle_name")
                    .IsRequired(false);
            });

        builder
            .HasIndex(u => u.Username)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(u => u.Username)
            .HasConversion(u => u.Value,
                v => Username.Create(v).Data)
            .HasColumnName("username")
            .HasMaxLength(Username.MaxUsernameLenght)
            .IsRequired();
        
        builder
            .Property(u => u.PasswordHash)
            .HasConversion(p => p.Value,
                v => PasswordHash.Create(v, v).Data)
            .HasColumnName("password_hash")
            .IsRequired();
        
        builder
            .Property(u => u.Gender)
            .HasConversion(g => g.Value,
                v => Gender.Create(v).Data)
            .HasColumnName("gender")
            .IsRequired();
        
        builder
            .HasIndex(u => u.Email)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(u => u.Email)
            .HasConversion(e => e.Value,
                v => Email.Create(v).Data)
            .HasColumnName("email")
            .HasMaxLength(Email.MaxEmailLenght)
            .IsRequired(false);
        
        builder
            .HasIndex(u => u.PhoneNumber)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(u => u.PhoneNumber)
            .HasConversion(p => p.Value,
                v => PhoneNumber.Create(v).Data)
            .HasColumnName("phone_number")
            .HasMaxLength(PhoneNumber.MaxPhoneNumberLenght)
            .IsRequired(false);

        builder
            .Property(u => u.IsActive)
            .HasColumnName("is_active");

        builder
            .Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        builder
            .Property(c => c.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired(false);
        builder
            .Property(c => c.IsDeleted)
            .HasColumnName("is_deleted");
        builder
            .Property(c => c.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);

        builder
            .HasOne<RoleEntity>()
            .WithMany()
            .HasForeignKey(u => u.RoleId);

    }
}