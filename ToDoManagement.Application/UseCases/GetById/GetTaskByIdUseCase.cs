using ToDoManagement.Communications.Responses;

namespace ToDoManagement.Application.UseCases.GetById;
public class GetTaskByIdUseCase
{
    private readonly List<ResponseTaskJson> _tasks;
    public GetTaskByIdUseCase(List<ResponseTaskJson> tasks)
    {
        _tasks = tasks;
    }

    public ResponseWrapper<ResponseTaskJson> Execute(int id)
    {
        var response = new ResponseWrapper<ResponseTaskJson>();

        for (int index = 0; index < _tasks.Count; index++)
        {
            if (id == _tasks[index].Id)
            {
                response.Success = true;
                response.Data = _tasks[index];
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
