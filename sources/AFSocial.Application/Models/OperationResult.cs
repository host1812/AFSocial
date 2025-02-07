namespace AFSocial.Application.Models;
public class OperationResult<T>
{
    public T? Value { get; set; }
    public bool IsError { get; set; }
    public List<OperationError> Errors { get; set; } = [];
}
