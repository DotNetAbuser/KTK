namespace Application.Responses.Identity;

public record RefreshTokenResponse(
    [property: JsonPropertyName("auth_token")]
    [property: Required]
    string AuthToken,
    [property: JsonPropertyName("refresh_token")]
    [property: Required]
    string RefreshToken);