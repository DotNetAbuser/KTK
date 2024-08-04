namespace Domain.Configurations;

public class CuratorCollectiveEntityConfiguration : IEntityTypeConfiguration<CuratorCollectiveEntity>
{
    public void Configure(EntityTypeBuilder<CuratorCollectiveEntity> builder)
    {
        builder
            .HasKey(cc => new { cc.CollectiveId, cc.CuratorId });
    }
}