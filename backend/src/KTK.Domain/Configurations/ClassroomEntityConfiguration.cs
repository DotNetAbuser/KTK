namespace Domain.Configurations;

public class ClassroomEntityConfiguration 
    : IEntityTypeConfiguration<ClassroomEntity>
{
    public void Configure(EntityTypeBuilder<ClassroomEntity> builder)
    {
        builder
            .HasQueryFilter(c => c.IsDeleted == false);
        
        builder
            .HasKey(c => c.Id)
            .HasName("ClassroomId");

        builder
            .HasIndex(c => c.Title)
            .IsUnique();
        builder
            .Property(c => c.Title)
            .HasMaxLength(256)
            .IsRequired();

        builder
            .HasIndex(c => c.Created)
            .IsUnique();
    }
}