using ToDoManagement.Communications.Enums;
using ToDoManagement.Communications.Requests;
using ToDoManagement.Communications.Responses;

namespace ToDoManagement.Application.UseCases.UpdateStatus;
public class UpdateTaskStatusUseCase
{
    private readonly List<ResponseTaskJson> _tasks;
    public UpdateTaskStatusUseCase(List<ResponseTaskJson> tasks)
    {
        _tasks = tasks;
    }

    public ResponseWrapper<string> Execute(int id, RequestUpdateTaskStatusJson request)
    {
        var response = new ResponseWrapper<string>();
        var result = new List<string>();
        for (int index = 0; index < _tasks.Count; index++)
        {
            if (id == _tasks[index].Id)
            {
                response.Success = true;

                result = ValidateStatus(_tasks[index], request.Status);

                if(result.Count != 0)
                {
                    response.Success = false;
                    response.Error = new ResponseErrorJson
                    {
                        Errors = result,
                    };

                    return response;
                }

                _tasks[index].Status = request.Status;
                break;
            }
        }

        if (!response.Success)
        {
            response.Error = new ResponseErrorJson
            {
                Errors = [$"Task with id {id} not found"],
            };
        }

        return response;
    }

    private List<string> ValidateStatus(ResponseTaskJson task, Status status)
    {
        var errors = new List<string>();

        if(task.Status == status)
        {
            errors.Add("Cannot update status for itself");
        }

        if (task.Status != Status.NotStarted && status == Status.NotStarted)
        {
            errors.Add("Cannot reverta task already initialized. You must finish it and start a new one.");
        }

        return errors;
    }
}
