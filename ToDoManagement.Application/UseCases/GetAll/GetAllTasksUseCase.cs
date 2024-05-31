using ToDoManagement.Communications.Responses;

namespace ToDoManagement.Application.UseCases.GetAll;
public class GetAllTasksUseCase
{
    private readonly List<ResponseTaskJson> _tasks;

    public GetAllTasksUseCase(List<ResponseTaskJson> tasks)
    {
        _tasks = tasks;
    }

    public List<ResponseTaskShortJson> Execute()
    {
        var tasksShort = new List<ResponseTaskShortJson>();

        for (int index = 0; index < _tasks.Count; index++)
        {
            tasksShort.Add(new ResponseTaskShortJson 
            { 
                Id = _tasks[index].Id, 
                Name = _tasks[index].Name, 
                Deadline = _tasks[index].Deadline 
            });
        }
        return tasksShort;
    }
}
