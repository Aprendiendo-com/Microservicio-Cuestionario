using AutoMapper;
using Microservicio_Cuestionario.Aplication.Services.Base;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.RespuestasDTO.ResponseDTO;
using Microservicio_Cuestionario.Domain.DTO.RespuestasDTO.ResquestDTO;
using Microservicio_Cuestionario.Domain.Entities;
using Microservicio_Cuestionario.Domain.Queries;
using Microservicio_Cuestionario.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Aplication.Services
{
    public class RepuestaService : GenericService, IRepuestaService
    {
        public RepuestaService(IRespuestaRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public  RespuestaAddDTO Add(RepuestaDTO repuestaDTO)
        {
            var respuesta = this._mapper.Map<Respuesta>(repuestaDTO);

            this.Repository.Add(respuesta);

            return this._mapper.Map<RespuestaAddDTO>(respuesta);
        }

        public void Edit(RespuestaUpdateDTO respuestaUpdateDTO)
        {
            var respuesta = this._mapper.Map<Respuesta>(respuestaUpdateDTO);

            this.Repository.Update(respuesta);
        }

        public List<RespuestaGetDTO> GetAll()
        {
            var respuesta = this.Repository.Traer<Respuesta>();

            var respuestaDTO = this._mapper.Map<List<RespuestaGetDTO>>(respuesta);

            return respuestaDTO;
        }
    }
}
