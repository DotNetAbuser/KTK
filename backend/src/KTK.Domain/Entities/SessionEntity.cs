namespace Domain.Entities;

public sealed class SessionEntity : BaseEntity<SessionId>
{
    public SessionEntity(SessionId id, UserEntity user, string token, DateTime expires)
        => (Id, UserId, Token, ExpiresAt) = (id, user.Id, token, expires);
    
    private SessionEntity() { }
    
    public UserId UserId { get; }
    public string Token { get; }
    public DateTime ExpiresAt { get; }
}