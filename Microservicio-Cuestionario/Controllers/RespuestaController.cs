using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.RespuestasDTO.ResquestDTO;
using Microservicio_Cuestionario.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio_Cuestionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestaController : ControllerBase
    {


        private readonly IRepuestaService service;

        public  RespuestaController(IRepuestaService services)
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

        //[HttpPost]
        //public IActionResult AddRespuesta(RepuestaDTO repuestaDTO)
        //{
        //    try
        //    {
        //        return new JsonResult(this.service.Add(repuestaDTO)) { StatusCode = 201 };
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpPut]
        public IActionResult Edit(RespuestaUpdateDTO respuestaUpdateDTO)
        {
            try
            {
                this.service.Edit(respuestaUpdateDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpDelete]

        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        this.service.Delete(id);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}



    }
}