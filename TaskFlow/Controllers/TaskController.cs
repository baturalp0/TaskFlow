using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List() 
        {
            return View();
        }

        public IActionResult Add() 
        {


            return View();
        }

    }
}
