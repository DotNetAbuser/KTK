namespace Domain.Entities;

public sealed class SessionEntity : BaseEntity
{
    public Guid SessionId { get; init; }
    public Guid UserId { get; }
    public string Token { get; }
    public DateTime Expires { get; }

    public ICollection<UserEntity> Users { get; } = [];

    public SessionEntity(Guid userId, string token, DateTime expires)
        => (UserId, Token, Expires) = (userId, token, expires);
}