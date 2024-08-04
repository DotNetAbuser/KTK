namespace Domain.Configurations;

public class SessionEntityConfiguration : IEntityTypeConfiguration<SessionEntity>
{
    public void Configure(EntityTypeBuilder<SessionEntity> builder)
    {
        builder
            .HasQueryFilter(s => s.IsDeleted == false);
        
        builder
            .HasKey(s => s.Id)
            .HasName("SessionId");

        builder
            .Property(s => s.UserId)
            .IsRequired();

        builder
            .Property(s => s.Token)
            .IsRequired();

        builder
            .Property(s => s.Expires)
            .IsRequired();

        builder
            .Property(s => s.Created)
            .IsRequired();

        builder
            .HasOne(s => s.User)
            .WithMany(u => u.Sessions)
            .HasForeignKey(s => s.UserId);
    }
}