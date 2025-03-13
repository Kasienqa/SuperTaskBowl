using SuperTaskBowl.DTOs;

namespace SuperTaskBowl.Services;

public interface ITaskService
{
    Task<IEnumerable<TaskDto>> GetTasksAsync();
    Task<TaskDto?> GetTaskByIdAsync(int id);
    Task AddTaskAsync(TaskDto task);
    Task UpdateTaskAsync(int id, TaskDto task);
    Task DeleteTaskAsync(int id);
}
