using ToDoManagement.Communications.Requests;
using ToDoManagement.Communications.Responses;

namespace ToDoManagement.Application.UseCases.Register;
public class RegisterTaskUseCase
{
    private readonly List<ResponseTaskJson> _tasks;

    public RegisterTaskUseCase(List<ResponseTaskJson> tasks)
    {
        _tasks = tasks;
    }

    public ResponseTaskJson Execute(RequestRegisterTaskJson request)
    {
        var task = new ResponseTaskJson
        {
            Id = _tasks.Count == 0 ? 1 : _tasks.Last().Id + 1,
            Name = request.Name,
            Priority = request.Priority,
            Deadline = request.Deadline,
        };

        _tasks.Add(task);

        return task;
    }
}
