using Microsoft.AspNetCore.Mvc;
using ApexAPI.Interface;
using ApexAPI.Models;
using ApexAPI.Repository;

namespace ApexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllDetails")]
        public ActionResult<List<Hospital>> GetAllDetails()
        {
            return StaticData.lsWards;
        }

        [HttpGet]
        [Route("GetAllDoctors")]
        public ActionResult<List<Doctor>> GetAllDoctors()
        {
            return StaticData.lsDoctors;
        }

        [HttpGet]
        [Route("GetAllPatients")]
        public ActionResult<List<Patient>> GetAllPatients()
        {
            return StaticData.lsPatients;
        }

        [HttpGet]
        [Route("GetPatientById/{id}")]
        public ActionResult<Patient> GetPatientById(int id)
        {
            return StaticData.lsPatients.Where(w => w.Id == id).FirstOrDefault();
        }
    }
}
