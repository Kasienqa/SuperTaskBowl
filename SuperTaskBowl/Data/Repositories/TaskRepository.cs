using Microsoft.EntityFrameworkCore;
using SuperTaskBowl.Models;

namespace SuperTaskBowl.Data.Repositories;
public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<TaskItem> GetAll()
    {
        return _context.Tasks.ToList();
    }

    public TaskItem? GetById(int id)
    {
        return _context.Tasks.Find(id);
    }

    public void Add(TaskItem task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public void Update(TaskItem task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}

