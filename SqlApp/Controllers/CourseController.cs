using Microsoft.AspNetCore.Mvc;
using SqlApp.Models;
using SqlApp.Services;

namespace SqlApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Course> courses = _courseService.GetCourses();
            return View(courses);
        }
    }
}
