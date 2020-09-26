using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio_Cuestionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaController : ControllerBase
    {
        private readonly IPreguntaService service;

        public PreguntaController(IPreguntaService services)
        {
            service = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return new JsonResult(this.service.GetAll()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddPregunta(PreguntaDTO preguntaDTO)
        {
            try
            {
                return new JsonResult(this.service.Add(preguntaDTO)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Edit( PreguntaUpdateDto preguntaUpdateDto)
        {
            try
            {
                this.service.Edit(preguntaUpdateDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            try
            {
                this.service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}