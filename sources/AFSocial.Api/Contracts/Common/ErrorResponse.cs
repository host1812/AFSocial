namespace AFSocial.Api.Contracts.Common;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string StatusMessage { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = [];
    public DateTime Timestamp { get; set; }
}
