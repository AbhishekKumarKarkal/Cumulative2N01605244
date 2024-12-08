using Cumulative2N01605244.Models;
using Microsoft.AspNetCore.Mvc;

public class TeacherPageController : Controller
{
    private readonly SchoolDbContext _context;

    public TeacherPageController(SchoolDbContext context)
    {
        _context = context;
    }

    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public IActionResult New(Teacher teacher)
    {
        if (!ModelState.IsValid)
            return View(teacher);

        _context.Teachers.Add(teacher);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult DeleteConfirm(int id)
    {
        var teacher = _context.Teachers.Find(id);
        return View(teacher);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var teacher = _context.Teachers.Find(id);
        if (teacher != null)
        {
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
