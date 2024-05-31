using Microsoft.AspNetCore.Mvc;
using ToDoManagement.Application.UseCases.Delete;
using ToDoManagement.Application.UseCases.GetAll;
using ToDoManagement.Application.UseCases.GetById;
using ToDoManagement.Application.UseCases.Register;
using ToDoManagement.Application.UseCases.Update;
using ToDoManagement.Application.UseCases.UpdateStatus;
using ToDoManagement.Communications.Requests;
using ToDoManagement.Communications.Responses;

namespace ToDoManagement.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly List<ResponseTaskJson> _tasks;

    public TasksController(List<ResponseTaskJson> tasks)
    {
        _tasks = tasks;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseTaskJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTasksUseCase(_tasks);
        var tasks = useCase.Execute();

        if(tasks.Count == 0)
        {
            return NoContent();
        }

        return Ok(tasks);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] int id)
    {
        var useCase = new GetTaskByIdUseCase(_tasks);
        var response = useCase.Execute(id);

        if (!response.Success)
        {
            return NotFound(response.Error);
        }

        return Ok(response.Data);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestRegisterTaskJson request)
    {
        var useCase = new RegisterTaskUseCase(_tasks);
        var task = useCase.Execute(request);
        return CreatedAtAction(nameof(Get), new { task.Id }, task);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestUpdateTaskJson request)
    {
        var useCase = new UpdateTaskUseCase(_tasks);
        var response = useCase.Execute(id, request);

        if (!response.Success)
        {
            return NotFound(response.Error);
        }

        return NoContent();
    }

    [HttpPatch]
    [Route("{id}/status")]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult UpdateStatus([FromRoute] int id, [FromBody] RequestUpdateTaskStatusJson request)
    {
        var useCase = new UpdateTaskStatusUseCase(_tasks);
        var response = useCase.Execute(id, request);

        if (!response.Success)
        {
            return NotFound(response.Error);
        }

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] int id)
    {
        var useCase = new DeleteTaskUseCase(_tasks);
        var response = useCase.Execute(id);

        if (!response.Success)
        {
            return NotFound(response.Error);
        }

        return NoContent();
    }
}
