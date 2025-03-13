using SuperTaskBowl.Data.Repositories;
using SuperTaskBowl.DTOs;
using SuperTaskBowl.Models;

namespace SuperTaskBowl.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public IEnumerable<TaskReadDto> GetTasks()
    {
        var tasks = _taskRepository.GetAll();
        return tasks.Select(t => new TaskReadDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            DueDate = t.DueDate,
            IsCompleted = t.IsCompleted
        }).ToList();
    }

    public TaskReadDto? GetTaskById(int id)
    {
        var task = _taskRepository.GetById(id);
        if (task == null) return null;
        return new TaskReadDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted
        };
    }

    public TaskReadDto AddTask(TaskCreateDto taskCreateDto)
    {
        var task = new TaskItem
        {
            Title = taskCreateDto.Title,
            Description = taskCreateDto.Description,
            DueDate = taskCreateDto.DueDate,
            IsCompleted = false
        };

        _taskRepository.Add(task);

        return new TaskReadDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted
        };
    }

    public TaskReadDto? UpdateTask(int id, TaskUpdateDto taskUpdateDto)
    {
        var task = _taskRepository.GetById(id);
        if (task == null) return null;

        task.Title = taskUpdateDto.Title;
        task.Description = taskUpdateDto.Description;
        task.DueDate = taskUpdateDto.DueDate;
        task.IsCompleted = taskUpdateDto.IsCompleted;

        _taskRepository.Update(task);

        return new TaskReadDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted
        };
    }

    public void DeleteTask(int id)
    {
        _taskRepository.Delete(id);
    }
}