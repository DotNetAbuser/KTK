namespace Application.Requests;

public record SignInRequest( 
    [property: JsonPropertyName("username")]
    [Required]
    string Username,
    [property: JsonPropertyName("password")]
    [Required]
    string Password);