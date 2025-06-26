using Microsoft.AspNetCore.Mvc;
using ApexAPI.Interface;
using ApexAPI.Models;
using ApexAPI.Repository;

namespace ApexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatient patients = new PatientRepository();

        [HttpGet]
        [Route("GetAllPatients")]
        public ActionResult GetAll()
        {
            var result = patients.GetAllPatients();
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("AddPatient")]
        [Consumes(contentType: "application/json")]
        public ActionResult Add([FromBody] Patient patient)
        {
            var result = patients.AddPatient(patient);
            if (result == false)
            {
                return StatusCode(500);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPut]
        [Route("UpdatePatientWardName/{id}")]
        [Consumes(contentType: "application/json")]
        public ActionResult Update([FromRoute] int id, [FromBody] string wardName)
        {
            var result = patients.UpdatePatientWardName(id, wardName);
            if (result == false)
            {
                return StatusCode(500);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
