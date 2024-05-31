using ToDoManagement.Communications.Requests;
using ToDoManagement.Communications.Responses;

namespace ToDoManagement.Application.UseCases.Update;
public class UpdateTaskUseCase
{
    private readonly List<ResponseTaskJson> _tasks;
    public UpdateTaskUseCase(List<ResponseTaskJson> tasks)
    {
        _tasks = tasks;
    }

    public ResponseWrapper<string> Execute(int id, RequestUpdateTaskJson request)
    {
        var response = new ResponseWrapper<string>();
        for (int index = 0; index < _tasks.Count; index++)
        {
            if (id == _tasks[index].Id)
            {
                response.Success = true;
                _tasks[index].Name = request.Name;
                _tasks[index].Priority = request.Priority;
                _tasks[index].Deadline = request.Deadline;

                break;
            }
        }

        if (!response.Success)
        {
            response.Error = new()
            {
                Errors = [$"Task with id {id} not found"]
            };
        }

        return response;
    }
}
