using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentDetails.Models;
using LayerDAL.Repository;
using LayerDAL.Entities;

namespace MyWebApp.Controllers;

public class HomeController : Controller
{
    private readonly IStudentRepository  _repository;

    public HomeController(IStudentRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> ShowStudent()
    {
        List<Student> ListStudent = await _repository.GetStudents();
        return View(ListStudent);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
