using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class UserEntity : BaseEntity<Guid>
{
    public UserEntity(
        int roleId,
        Name name,
        string username,
        string passwordHash,
        char gender,
        string email,
        string phoneNumber,
        bool isActive)
    {
        RoleId = roleId;
        Name = name;
        Username = username;
        PasswordHash = passwordHash;
        Gender = gender;
        Email = email;
        PhoneNumber = phoneNumber;
        IsActive = isActive;
    }

    private UserEntity() { }
    
    public int RoleId { get; set; }
    public Name Name { get; private set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public char Gender { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsActive { get; set; }

    public RoleEntity Role { get; } = null!;
    public ICollection<SessionEntity> Sessions { get; } = [];
    public ICollection<CollectiveEntity> Collectives { get; } = [];
    public ICollection<SubjectEntity> Subjects { get; } = [];
    
    public void UpdateName(Name name)
    {
        if (name == null) throw new ArgumentException("Name cannot be null!");
        if (Name.Equals(name)) return;
        Name = name;
    }
}