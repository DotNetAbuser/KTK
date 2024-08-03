namespace Application.Requests.Identity;

public record SignInRequest( 
    [property: JsonPropertyName("username")]
    [Required]
    [MinLength(StudentEntity.MIN_USERNAME_LENGHT)]
    [MaxLength(StudentEntity.MAX_USERNAME_LENGHT)]
    string Username,
    [property: JsonPropertyName("password")]
    [Required]
    [MinLength(StudentEntity.MIN_PASSWORD_LENGHT)]
    [MaxLength(StudentEntity.MAX_PASSWORD_LENGHT)]
    string Password);