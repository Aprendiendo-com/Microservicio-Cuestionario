using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservicio_Cuestionario.Domain.Entities;
using Microservicio_Cuestionario.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio_Cuestionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuestionarioController : ControllerBase
    {
        private ICuestionarioService service;
        public CuestionarioController(ICuestionarioService services) {
            service = services;
        }

        /*[HttpGet]
        
        public List<> GetAll() {
            try
            {
                return service.Traer<List<>>();
                //return service.Traer<List<Cuestionario>>();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }*/


    }

}
