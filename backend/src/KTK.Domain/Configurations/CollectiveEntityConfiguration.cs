namespace Domain.Configurations;

public class CollectiveEntityConfiguration 
    : IEntityTypeConfiguration<CollectiveEntity>
{
    public void Configure(EntityTypeBuilder<CollectiveEntity> builder)
    {
        builder
            .HasQueryFilter(c => c.IsDeleted == false);
        
        builder
            .HasKey(c => c.Id)
            .HasName("CollectiveId");

        builder
            .Property(c => c.SpecialityId)
            .IsRequired();

        builder
            .HasIndex(c => c.Title)
            .IsUnique();
        builder
            .Property(c => c.Title)
            .HasMaxLength(256)
            .IsRequired();

        builder
            .Property(c => c.EnrollmentDate)
            .IsRequired();

        builder
            .Property(c => c.DeducationDate)
            .IsRequired();
        
        builder
            .HasOne(c => c.Specialty)
            .WithMany(s => s.Collectives)
            .HasForeignKey(c => c.SpecialityId);

        builder
            .HasMany(c => c.Students)
            .WithMany(u => u.Collectives)
            .UsingEntity<StudentCollectiveEntity>(
                l => l.HasOne<UserEntity>().WithMany().HasForeignKey(u => u.StudentId),
                r => r.HasOne<CollectiveEntity>().WithMany().HasForeignKey(c => c.CollectiveId));

        builder
            .HasMany(c => c.Curators)
            .WithMany(u => u.Collectives)
            .UsingEntity<CuratorCollectiveEntity>(
                l => l.HasOne<UserEntity>().WithMany().HasForeignKey(u => u.CuratorId),
                r => r.HasOne<CollectiveEntity>().WithMany().HasForeignKey(c => c.CollectiveId));

    }
}