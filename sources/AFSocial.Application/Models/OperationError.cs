namespace AFSocial.Application.Models;
public class OperationError
{
    public ErrorCode Code { get; set; }
    public string Message { get; set; } = string.Empty;
}
