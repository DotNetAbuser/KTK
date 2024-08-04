using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasQueryFilter(u => u.IsDeleted == false);
        
        builder
            .HasKey(u => u.Id)
            .HasName("UserId");

        builder
            .Property(u => u.RoleId)
            .IsRequired();

        builder
            .ComplexProperty(u => u.Name, name =>
            {
                name
                    .Property(n => n.Last)
                    .HasColumnName("LastName")
                    .IsRequired();
                name
                    .Property(n => n.First)
                    .HasColumnName("FirstName")
                    .IsRequired();
                name
                    .Property(n => n.Middle)
                    .HasColumnName("MiddleName");
            });

        builder
            .HasIndex(u => u.Username)
            .IsUnique();
        builder
            .Property(u => u.Username)
            .HasMaxLength(64)
            .IsRequired();

        builder
            .Property(u => u.PasswordHash)
            .IsRequired();

        builder
            .Property(u => u.Gender)
            .IsRequired();

        builder
            .HasIndex(u => u.Email)
            .IsUnique();
        builder
            .Property(u => u.Email)
            .HasMaxLength(256)
            .IsRequired(false);;

        builder
            .HasIndex(u => u.PhoneNumber)
            .IsUnique();
        builder
            .Property(u => u.PhoneNumber)
            .HasMaxLength(32)
            .IsRequired(false);


        builder
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        builder
            .HasMany(u => u.Collectives)
            .WithMany(c => c.Students)
            .UsingEntity<StudentCollectiveEntity>(
                l => l.HasOne<CollectiveEntity>().WithMany().HasForeignKey(c => c.CollectiveId),
                r => r.HasOne<UserEntity>().WithMany().HasForeignKey(u => u.StudentId));

        builder
            .HasMany(u => u.Collectives)
            .WithMany(c => c.Curators)
            .UsingEntity<CuratorCollectiveEntity>(
                l => l.HasOne<CollectiveEntity>().WithMany().HasForeignKey(c => c.CollectiveId),
                r => r.HasOne<UserEntity>().WithMany().HasForeignKey(u => u.CuratorId));

        builder
            .HasMany(u => u.Subjects)
            .WithMany(s => s.Rectors)
            .UsingEntity<RectorSubjectEntity>(
                l => l.HasOne<SubjectEntity>().WithMany().HasForeignKey(s => s.SubjectId),
                r => r.HasOne<UserEntity>().WithMany().HasForeignKey(u => u.RectorId));

    }
}