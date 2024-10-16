using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Data
{
    public class TaskRepository
    {
        private List<TaskItem> _tasks = new List<TaskItem>();
        private int _nextId = 1;



        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }
        

        public TaskRepository()
        {
            _tasks.Add(new TaskItem { Id = _nextId++, Title = "Task 1", IsCompleted = false });
            _tasks.Add(new TaskItem { Id = _nextId++, Title = "Task 2", IsCompleted = true });
        }



        public void AddTask(TaskItem task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
            foreach(var item in _tasks)
                Console.WriteLine(item.Title);
        }

        public TaskItem GetTaskById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public void UpdateTask (TaskItem UpdatedTask)
        {
            var task = GetTaskById(UpdatedTask.Id);
            if (task != null) { 
                task.Title = UpdatedTask.Title;
                task.IsCompleted = UpdatedTask.IsCompleted;
            }
        }

        public void DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null) _tasks.Remove(task);
        }
    }
}
