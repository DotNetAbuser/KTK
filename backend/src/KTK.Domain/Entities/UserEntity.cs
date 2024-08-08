using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class UserEntity 
    : BaseEntity<UserId>
{
    public UserEntity(
        RoleEntity role,
        Name name,
        Username username,
        PasswordHash passwordHash,
        Gender gender,
        Email email,
        PhoneNumber phoneNumber,
        bool isActive)
    {
        RoleId = role.Id;
        Name = name;
        Username = username;
        PasswordHash = passwordHash;
        Gender = gender;
        Email = email;
        PhoneNumber = phoneNumber;
        IsActive = isActive;
    }

    private UserEntity() { }
    
    public RoleId RoleId { get; set; }
    public Name Name { get; set; }
    public Username Username { get; set; }
    public PasswordHash PasswordHash { get; set; }
    public Gender Gender { get; set; }
    public Email Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public bool IsActive { get; set; }
}