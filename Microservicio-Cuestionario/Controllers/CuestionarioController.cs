using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.Entities;
using Microservicio_Cuestionario.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio_Cuestionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuestionarioController : ControllerBase
    {
        private readonly ICuestionarioService service;
        public CuestionarioController(ICuestionarioService services) {

            service = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return new JsonResult(service.GetAll()) { StatusCode = 200 }; 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(CuestionarioDTO cuestionarioDto)
        {
            try
            {
                return new JsonResult(service.AddCuestionario(cuestionarioDto)) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Edit(CuestionarioDTO cuestionarioDTO)
        {
            try
            {
                service.Update(cuestionarioDTO);
                return Ok();
                //return new JsonResult(service.Update(cuestionarioDTO)) { StatusCode = 201};
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
