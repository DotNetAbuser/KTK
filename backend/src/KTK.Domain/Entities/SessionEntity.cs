namespace Domain.Entities;

public sealed class SessionEntity : BaseEntity<int>
{
    public SessionEntity(Guid userId, string token, DateTime expires)
        => (UserId, Token, Expires) = (userId, token, expires);
    private SessionEntity() { }
    
    public Guid UserId { get; }
    public string Token { get; }
    public DateTime Expires { get; }

    public UserEntity User { get; } = null!;
}