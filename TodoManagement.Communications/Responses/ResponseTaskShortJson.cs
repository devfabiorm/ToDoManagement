namespace ToDoManagement.Communications.Responses;
public class ResponseTaskShortJson
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateOnly Deadline { get; set; }
}
