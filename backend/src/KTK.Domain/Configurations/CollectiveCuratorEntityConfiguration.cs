namespace Domain.Configurations;

public class CollectiveCuratorEntityConfiguration : IEntityTypeConfiguration<CollectiveCuratorEntity>
{
    public void Configure(EntityTypeBuilder<CollectiveCuratorEntity> builder)
    {
        builder
            .HasKey(cc => new { cc.CollectiveId, cc.CuratorId });

        builder
            .Property(cc => cc.CollectiveId)
            .HasColumnName("collective_id")
            .IsRequired();
        
        builder
            .Property(cc => cc.CuratorId)
            .HasColumnName("curator_id")
            .IsRequired();

        builder
            .HasOne<CollectiveEntity>()
            .WithMany()
            .HasForeignKey(cc => cc.CollectiveId);

        builder
            .HasOne<UserEntity>()
            .WithMany()
            .HasForeignKey(cc => cc.CuratorId);
    }
}