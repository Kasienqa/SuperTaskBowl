using Microsoft.AspNetCore.Mvc;
using SuperTaskBowl.DTOs;
using SuperTaskBowl.Services;

namespace SuperTaskBowl.Controllers;

[ApiController]
[Route("/api/tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("")]
    public List<TaskReadDto> GetTaskList()
    {
        return _taskService.GetTasks().ToList();
    }

    [HttpGet("{id}")]
    public TaskReadDto GetTask([FromRoute] int id)
    {
        var task = _taskService.GetTaskById(id);
        if (task == null)
        {
            throw new KeyNotFoundException($"Zadanie o ID {id} nie zostało znalezione.");
        }
        return task;
    }

    [HttpPost("")]
    public TaskReadDto AddTask([FromBody] TaskCreateDto taskCreateDto)
    {
        if (string.IsNullOrWhiteSpace(taskCreateDto.Title))
        {
            throw new ArgumentException("Tytuł zadania nie może być pusty.");
        }

        return _taskService.AddTask(taskCreateDto);
    }

    [HttpPut("{id}")]
    public TaskReadDto UpdateTask([FromRoute] int id, [FromBody] TaskUpdateDto taskUpdateDto)
    {
        if (string.IsNullOrWhiteSpace(taskUpdateDto.Title))
        {
            throw new ArgumentException("Tytuł zadania nie może być pusty.");
        }

        var updatedTask = _taskService.UpdateTask(id, taskUpdateDto);
        if (updatedTask == null)
        {
            throw new KeyNotFoundException($"Zadanie o ID {id} nie zostało znalezione.");
        }
        return updatedTask;
    }

    [HttpDelete("{id}")]
    public void DeleteTask([FromRoute] int id)
    {
        var task = _taskService.GetTaskById(id);
        if (task == null)
        {
            throw new KeyNotFoundException($"Zadanie o ID {id} nie zostało znalezione.");
        }

        _taskService.DeleteTask(id);
    }
}