namespace Domain.Configurations;

public class SessionEntityConfiguration : IEntityTypeConfiguration<SessionEntity>
{
    public void Configure(EntityTypeBuilder<SessionEntity> builder)
    {
        builder
            .HasQueryFilter(s => s.IsDeleted == false);

        builder
            .HasKey(s => s.Id);
        builder
            .Property(s => s.Id)
            .HasConversion(s => s.Value,
                v => new SessionId(v))
            .HasColumnName("session_id")
            .IsRequired();

        builder
            .Property(s => s.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder
            .Property(s => s.Token)
            .HasColumnName("token")
            .IsRequired();

        builder
            .Property(s => s.ExpiresAt)
            .HasColumnName("expires_at")
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
            .HasOne<UserEntity>()
            .WithMany()
            .HasForeignKey(s => s.UserId);
    }
}