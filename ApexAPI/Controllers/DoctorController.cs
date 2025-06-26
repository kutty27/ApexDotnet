using Microsoft.AspNetCore.Mvc;
using ApexAPI.Interface;
using ApexAPI.Models;
using ApexAPI.Repository;

namespace ApexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctor doctors = new DoctorRepository();

        [HttpGet]
        [Route("GetAllDoctors")]
        public ActionResult GetAll()
        {
            var result = doctors.GetAllDoctors();
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet]
        [Route("GetDoctorsByWardName/{wardName}")]
        public ActionResult GetByName(string wardName)
        {
            var result = doctors.GetDoctorsByWardName(wardName);
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost]
        [Route("AddDoctor")]
        [Consumes(contentType: "application/json")]
        public IActionResult Add([FromBody] Doctor doctor)
        {
            var result = doctors.AddDoctor(doctor);
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
        [Route("UpdateDoctorContact/{id}")]
        [Consumes(contentType: "application/json")]
        public ActionResult Update([FromRoute] int id, [FromBody] long contactNo)
        {
            var result = doctors.UpdateDoctorContact(id, contactNo);
            if (result == false)
            {
                return StatusCode(500);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete]
        [Route("RemoveDoctor/{id}")]
        [Consumes(contentType: "application/json")]
        public ActionResult Delete(int id)
        {
            var result = doctors.RemoveDoctor(id);
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
