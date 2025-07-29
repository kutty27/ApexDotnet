using Microsoft.AspNetCore.Mvc;
using ApexAPI.Interface;
using ApexAPI.Models;
using ApexAPI.Repository;

namespace ApexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private IHospital wards = new HospitalRepository();

        [HttpGet]
        [Route("GetAllDetails")]
        public ActionResult GetAll()
        {
            var result  = wards.GetAllDetails();
            if(result.Count() > 0)
            {
                return Ok(result);
            }
            return BadRequest(result);

           // return wards.GetAllDetails();
        }

        [HttpGet]
        [Route("GetWardDetailsById/{id}")]
        public ActionResult GetById(int id)
        {
            var result = wards.GetWardDetailsById(id);

            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        [Route("GetWardWithMaxBedCountAvailable")]
        public ActionResult GetAvailability()
        {
            var result = wards.GetWardWithMaxBedCountAvailable();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
