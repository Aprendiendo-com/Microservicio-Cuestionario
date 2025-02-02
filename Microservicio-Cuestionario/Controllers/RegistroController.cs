﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.RegistrosDTO.ResquestDTO;
using Microservicio_Cuestionario.Domain.Entities;
using Microservicio_Cuestionario.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio_Cuestionario.Controllers
{
    [Route("api/Registro")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroService service;
        public RegistroController(IRegistroService services)
        {

            service = services;
        }

        [HttpPost]
        public IActionResult Add(RegistroAddDTO registroDTO)
        {
            try
            {
                return new JsonResult(service.AddRegistro(registroDTO)) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //MODIFICADO
        [HttpPost("PostConClase")]
        public IActionResult AddConClase(RegistroRequestDTO registroDTO)
        {
            try
            {
                return new JsonResult(service.AddRegistroConClase(registroDTO)) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpPut]
        //public IActionResult Edit(RegistroDTO registroDTO)
        //{
        //    try
        //    {
        //        service.Update(registroDTO);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

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
        //MODIFICADO
        [HttpGet("ConClase")]
        public IActionResult GetAllConClase()
        {
            try
            {
                return new JsonResult(service.GetAllConClase()) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpDelete("DeleteById")]
        //public IActionResult DeleteBy(int id)
        //{
        //    try
        //    {
        //        service.DeleteRegistroById(id);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


    }
}
