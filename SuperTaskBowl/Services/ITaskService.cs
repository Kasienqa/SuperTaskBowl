using SuperTaskBowl.DTOs;

namespace SuperTaskBowl.Services;

public interface ITaskService
{
        IEnumerable<TaskReadDto> GetTasks();
        TaskReadDto? GetTaskById(int id);
        TaskReadDto AddTask(TaskCreateDto taskCreateDto);
        TaskReadDto? UpdateTask(int id, TaskUpdateDto taskUpdateDto);
        void DeleteTask(int id);
}