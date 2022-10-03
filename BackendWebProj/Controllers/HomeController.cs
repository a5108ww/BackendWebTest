using BackendWebProj.Helper;
using BackendWebProj.Models;
using BackendWebProj.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BackendWebProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployRepository employRepository;
        public HomeController(EmployRepository _employRepository)
        {
            employRepository = _employRepository;
        }

        public IActionResult Index()
        {
            IQueryable<Employ> employs = employRepository.GetEntitiesQ();
            List<Employ> result = employs.ToList();
            return View();
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

        [HttpPost]
        public async Task<string> SaveData(List<Employ> editEmploys)
        {
            IQueryable<Employ> employs = employRepository.GetEntitiesQ();
            return StringHelper.ConvertObjectToJsonString(employs);
        }
    }
}