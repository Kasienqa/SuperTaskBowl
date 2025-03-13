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

    public async Task<IEnumerable<TaskDto>> GetTasksAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();
        return tasks.Select(t => new TaskDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            DueDate = t.DueDate,
            IsCompleted = t.IsCompleted
        });
    }

    public async Task<TaskDto?> GetTaskByIdAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return task == null ? null : new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted
        };
    }

    public async Task AddTaskAsync(TaskDto taskDto)
    {
        var task = new TaskItem
        {
            Title = taskDto.Title,
            Description = taskDto.Description,
            DueDate = taskDto.DueDate,
            IsCompleted = taskDto.IsCompleted
        };
        await _taskRepository.AddAsync(task);
    }

    public async Task UpdateTaskAsync(int id, TaskDto taskDto)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        if (task != null)
        {
            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.DueDate = taskDto.DueDate;
            task.IsCompleted = taskDto.IsCompleted;
            await _taskRepository.UpdateAsync(task);
        }
    }

    public async Task DeleteTaskAsync(int id)
    {
        await _taskRepository.DeleteAsync(id);
    }
}
