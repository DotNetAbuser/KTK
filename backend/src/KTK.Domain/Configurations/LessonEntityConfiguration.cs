namespace Domain.Configurations;

public class LessonEntityConfiguration :IEntityTypeConfiguration<LessonEntity>
{
    public void Configure(EntityTypeBuilder<LessonEntity> builder)
    {
        builder
            .HasQueryFilter(c => c.IsDeleted == false);
        
        builder
            .HasKey(l => l.Id);
        builder
            .Property(l => l.Id)
            .HasConversion(l => l.Value,
                v => new LessonId(v))
            .HasColumnName("lesson_id")
            .IsRequired();

        builder
            .Property(l => l.ClassroomId)
            .HasColumnName("classroom_id")
            .IsRequired();

        builder
            .Property(l => l.CollectiveId)
            .HasColumnName("collective_id")
            .IsRequired();

        builder
            .Property(l => l.SubjectId)
            .HasColumnName("subject_id")
            .IsRequired();
        
        builder
            .Property(l => l.TeacherId)
            .HasColumnName("teacher_id")
            .IsRequired();

        builder
            .Property(l => l.LessonStatusId)
            .HasColumnName("lesson_status_id")
            .IsRequired();

        builder
            .Property(l => l.SubGroup)
            .HasColumnName("sub_group")
            .IsRequired();

        builder
            .Property(l => l.StartAt)
            .HasColumnName("start_at")
            .IsRequired();

        builder
            .Property(l => l.EndAt)
            .HasColumnName("end_at")
            .IsRequired();

        builder
            .Property(l => l.StudyAt)
            .HasColumnName("study_at")
            .IsRequired();
        
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
            .HasOne<ClassroomEntity>()
            .WithMany()
            .HasForeignKey(l => l.ClassroomId);

        builder
            .HasOne<CollectiveEntity>()
            .WithMany()
            .HasForeignKey(l => l.CollectiveId);

        builder
            .HasOne<SubjectEntity>()
            .WithMany()
            .HasForeignKey(l => l.SubjectId);

        builder
            .HasOne<UserEntity>()
            .WithMany()
            .HasForeignKey(l => l.TeacherId);

        builder
            .HasOne<LessonStatusEntity>()
            .WithMany()
            .HasForeignKey(l => l.LessonStatusId);
    }
}