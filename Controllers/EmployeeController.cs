using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}
