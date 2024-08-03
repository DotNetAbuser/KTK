namespace Application.Responses.Common;

public record ClassroomResponse(
    long Id,
    string Title,
    bool IsActive);