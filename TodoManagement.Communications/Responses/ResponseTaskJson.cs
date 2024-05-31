using ToDoManagement.Communications.Enums;

namespace ToDoManagement.Communications.Responses;
public class ResponseTaskJson
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Severity Priority { get; set; }
    public Status Status { get; set; }
    public DateOnly Deadline { get; set; }
}
