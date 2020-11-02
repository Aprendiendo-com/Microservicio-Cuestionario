using AutoMapper;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.DTOResponse;
using Microservicio_Cuestionario.Domain.DTO.PreguntasDTO.ResponseDTO;
using Microservicio_Cuestionario.Domain.DTO.RegistrosDTO.ResponseDTO;
using Microservicio_Cuestionario.Domain.DTO.RegistrosDTO.ResquestDTO;
using Microservicio_Cuestionario.Domain.DTO.RespuestasDTO.ResponseDTO;
using Microservicio_Cuestionario.Domain.DTO.RespuestasDTO.ResquestDTO;
using Microservicio_Cuestionario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Aplication.Services
{
    public class AutoMappingProfile : Profile
    {

        public AutoMappingProfile()
        {
            CreateMap<CuestionarioDTO, Cuestionario>(); // este mapeo es de add
            CreateMap<Cuestionario, CuestionarioRespuestaDTO>(); // mapeo del dto q devuelve el metodo add

            CreateMap<Cuestionario, CuestionarioGetDTO>(); // este es un get

            CreateMap<CuestionarioUpdateDTO , Cuestionario>(); // este es un update


            CreateMap<PreguntaDTO, Pregunta>(); // este es un add
            CreateMap<Pregunta, PreguntaRespuestaDTO>(); // este es un add valor retornado

            CreateMap<PreguntaUpdateDto, Pregunta>(); // este es un update

            CreateMap<Pregunta, PreguntaGetDTO>(); // esto es un get



            CreateMap<RepuestaDTO, Respuesta>(); // esto es de un add
            CreateMap<Respuesta, RespuestaAddDTO>(); // valor retornado del add

            CreateMap<RespuestaUpdateDTO, Respuesta>(); // esto es del edit

            CreateMap<Respuesta, RespuestaGetDTO>(); // esto es del get


            CreateMap<Registro, RegistroDTO>(); //esto es de get

            CreateMap<RegistroAddDTO, Registro>(); // esto es del add
            CreateMap<Registro, RegistroRespuestaDTO>(); // lo que devuelve add



            CreateMap<Registro, RegistroRequestDTO>(); // lo que devuelve add
            CreateMap<RegistroRequestDTO, Registro>(); // lo que devuelve add


            CreateMap<Registro, RegistroRespuestaDTO>(); // lo que devuelve add
            CreateMap<RegistroRespuestaDTO, Registro>(); // lo que devuelve add


            CreateMap<Registro, RegistroResponseDTO>(); // lo que devuelve add
            CreateMap<RegistroResponseDTO, Registro>(); // lo que devuelve add

        }


    }
}
