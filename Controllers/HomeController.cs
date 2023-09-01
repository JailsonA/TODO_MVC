using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TODO_MVC.Data;
using TODO_MVC.Models;

namespace TODO_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TodoDBContext _context;
        public HomeController(ILogger<HomeController> logger, TodoDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Todos.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(TodoModel todo)
        {
            if (ModelState.IsValid)
            {
                todo.Date = DateTime.Now;
                _context.Todos.Add(todo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        public JsonResult Delete(int id)
        {
            TodoModel todo = _context.Todos.Find(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
            }
            return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TodoModel todo = _context.Todos.Find(id);
            if (todo != null)
            {
                return View(todo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(TodoModel todo)
        {
            if (ModelState.IsValid)
            {
                _context.Todos.Update(todo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        public IActionResult Details(int id)
        {
            TodoModel todo = _context.Todos.Find(id);
            if (todo != null)
            {
                return View(todo);
            }
            return RedirectToAction("Index");
        }

        public IActionResult IsChecked(int id)
        {
            TodoModel todo = _context.Todos.Find(id);
            if (todo != null)
            {
                todo.IsDone = !todo.IsDone;
                _context.Todos.Update(todo);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}