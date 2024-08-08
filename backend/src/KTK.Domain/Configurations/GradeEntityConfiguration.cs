namespace Domain.Configurations;

public class GradeEntityConfiguration : IEntityTypeConfiguration<GradeEntity>
{
    public void Configure(EntityTypeBuilder<GradeEntity> builder)
    {
        builder
            .HasKey(g => g.Id);
        builder
            .Property(g => g.Id)
            .HasConversion(i => i.Value,
                v => new GradeId(v))
            .HasColumnName("grade_id")
            .IsRequired();

        builder
            .Property(g => g.LessonId)
            .HasColumnName("lesson_id")
            .IsRequired();

        builder
            .Property(g => g.StudentId)
            .HasColumnName("student_id")
            .IsRequired();

        builder
            .Property(g => g.GradeTypeId)
            .HasColumnName("grade_type_id")
            .IsRequired();

        builder
            .OwnsOne(g => g.Description, description =>
            {
                description
                    .Property(d => d.Value)
                    .HasColumnName("description")
                    .HasMaxLength(Description.MaxDescriptionLenght)
                    .IsRequired(false);
            });
        
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
            .HasOne<LessonEntity>()
            .WithMany()
            .HasForeignKey(g => g.LessonId);

        builder
            .HasOne<UserEntity>()
            .WithMany()
            .HasForeignKey(g => g.StudentId);

        builder
            .HasOne<GradeTypeEntity>()
            .WithMany()
            .HasForeignKey(g => g.GradeTypeId);
    }
}