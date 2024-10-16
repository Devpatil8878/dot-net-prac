
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TasksController : Controller
    {

        private readonly TaskRepository _taskRepository;

        public TasksController()
        {
            _taskRepository = new TaskRepository();
        }

        public IActionResult Index()
        {
            var tasks = _taskRepository.GetAllTasks();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            _taskRepository.AddTask(task);
            return RedirectToAction("index");
            
            return View(task);
        }

        public IActionResult Edit(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if(task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskItem task)
        {

            _taskRepository.UpdateTask(task);
            return RedirectToAction("Index");
            

            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _taskRepository.DeleteTask(id);
            return RedirectToAction("Index");
        }

    }
}
