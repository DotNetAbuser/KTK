namespace Application.Requests.Identity;

public record RefreshTokenRequest(
    [property: JsonPropertyName("auth_token")]
    [property: Required]
    string AuthToken,
    [property: JsonPropertyName("refresh_token")]
    [property: Required]
    string RefreshToken);