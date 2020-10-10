using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.CuestionariosDTO.DTORequest;
using Microservicio_Cuestionario.Domain.DTO.DTO_Compuestos;
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
        
        [HttpGet("Completo")]
        public IActionResult GetCompleto()
        {
            try
            {
                return new JsonResult(service.GetCompleto()) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("CompletoConRespuestasCorrectas")]
        public IActionResult GetConRespuestasCorrectas()
        {
            try
            {
                return new JsonResult(service.GetCompletoConRespuestasCorrectas()) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        //modificado

        [HttpPost]
        public IActionResult AddCompleto(CuestionarioTodoDTO cuestionarioTodoDto)
        {
            try
            {
                return new JsonResult(service.AddCuestionario(cuestionarioTodoDto)) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpPut]
        public IActionResult Edit(CuestionarioUpdateDTO cuestionarioUpdateDTO)
        {
            try
            {
                service.Update(cuestionarioUpdateDTO);
                return Ok();
                //return new JsonResult(service.Update(cuestionarioDTO)) { StatusCode = 201};
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cuestionario")]

        public IActionResult Cuestionario(CuestionarioACorregirDTO cuestionario)
        {
            try
            {
                return new JsonResult(this.service.CorreccionCuestionario(cuestionario)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



        //[HttpPost]
        //public IActionResult Add(CuestionarioDTO cuestionarioDto)
        //{
        //    try
        //    {
        //        return new JsonResult(service.AddCuestionario(cuestionarioDto)) { StatusCode = 201 };
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        //Modificado
        //[HttpDelete]
        //public IActionResult Delete(CuestionarioDTO cuestionarioDto)
        //{
        //    try
        //    {
        //        service.DeleteCuestionario(cuestionarioDto);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpDelete("DeleteById")]
        //public IActionResult DeleteBy(int id)
        //{
        //    try
        //    {
        //        service.DeleteCuestionarioById(id);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpGet("FindById")]
        //public IActionResult FindBy(int id)
        //{
        //    try
        //    {
        //        return new JsonResult(service.FindCuestionarioById(id)) { StatusCode = 200 };
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
    //add-get-delete-update

}
