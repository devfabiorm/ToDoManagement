namespace ToDoManagement.Communications.Responses;
public class ResponseWrapper<T>
{
    public bool Success { get; set; }
    public ResponseErrorJson? Error { get; set; }
    public T? Data { get; set; }
}
