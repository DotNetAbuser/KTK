namespace Domain.Entities;

public class CuratorCollectiveEntity 
{
    public CuratorCollectiveEntity(Guid curatorId, int collectiveId)
        => (CuratorId, CollectiveId) = (curatorId, collectiveId);

    private CuratorCollectiveEntity() { }
    
    public Guid CuratorId { get; set; }
    public int CollectiveId { get; set; }
    

}