namespace Domain.Entities;

public class CuratorCollectiveEntity : BaseEntity
{
    public Guid CuratorId { get; set; }
    public int CollectiveId { get; set; }

    public UserEntity Curator { get; } = null!;
    public CollectiveEntity Collective { get; } = null!;
    
    public CuratorCollectiveEntity(Guid curatorId, int collectiveId)
        => (CuratorId, CollectiveId) = (curatorId, collectiveId);
}