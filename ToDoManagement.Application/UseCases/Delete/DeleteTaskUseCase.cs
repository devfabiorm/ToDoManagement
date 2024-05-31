using ToDoManagement.Communications.Responses;

namespace ToDoManagement.Application.UseCases.Delete;
public class DeleteTaskUseCase
{
    private readonly List<ResponseTaskJson> _tasks;
    public DeleteTaskUseCase(List<ResponseTaskJson> tasks)
    {
        _tasks = tasks;
    }

    public ResponseWrapper<string> Execute(int id)
    {
        var response = new ResponseWrapper<string>();

        for (int index = 0; index < _tasks.Count; index++)
        {
            if (id == _tasks[index].Id)
            {
                response.Success = true;
                _tasks.RemoveAt(index);
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
