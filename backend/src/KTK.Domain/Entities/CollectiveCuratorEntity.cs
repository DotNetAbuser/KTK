namespace Domain.Entities;

public class CollectiveCuratorEntity 
{
    public CollectiveCuratorEntity(CollectiveEntity collective, UserEntity curator)
        => (CollectiveId, CuratorId) = (collective.Id, curator.Id);

    private CollectiveCuratorEntity() { }
    
    public CollectiveId CollectiveId { get; set; }
    public UserId CuratorId { get; set; }

    

}