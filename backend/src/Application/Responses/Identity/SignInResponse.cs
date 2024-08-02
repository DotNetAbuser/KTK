namespace Application.Responses;

public record SignInResponse(  
    [property: JsonPropertyName("auth_token")]
    [property: Required]
    string AuthToken,
    [property: JsonPropertyName("refresh_token")]
    [property: Required]
    string RefreshToken);