using BackendWebProj.Helper;
using BackendWebProj.Models;
using BackendWebProj.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebProj.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployController : Controller
    {
        private readonly EmployRepository employRepository;
        public EmployController(EmployRepository _employRepository)
        {
            employRepository = _employRepository;
        }

        [HttpGet]
        [Route("GetData")]
        public string GetData()
        {
            IQueryable<Employ> employs = employRepository.GetEntitiesQ();
            return StringHelper.ConvertObjectToJsonString(employs);
        }

        [HttpPost]
        [Route("SaveData")]
        public async Task<string> SaveData([FromBody]List<Employ> editEmploys)
        {
            string result = await employRepository.SaveEntity(editEmploys);

            IQueryable<Employ> employs = employRepository.GetEntitiesQ();
            return StringHelper.ConvertObjectToJsonString(employs);
        }
    }
}
