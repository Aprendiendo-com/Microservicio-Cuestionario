using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microservicio_Cuestionario.AccessData.Command;
using Microservicio_Cuestionario.AccessData.Context;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.CuestionariosDTO.DTORequest;
using Microservicio_Cuestionario.Domain.DTO.PreguntasDTO.ResponseDTO;
using Microservicio_Cuestionario.Domain.DTO.RespuestasDTO.ResquestDTO;
using Microservicio_Cuestionario.Domain.Entities;
using Microservicio_Cuestionario.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Microservicio_Cuestionario.AccessData.Queries
{
    public class CuestionarioRepository : GenericRepository, ICuestionarioRepository
    {
        public CuestionarioRepository(GenericContext contexto) : base(contexto)
        {
        }

        public CuestionarioTodoDTO GetCuestionarioCompleto(Cuestionario cuestionario)
        {
            PreguntaConRespuestaDTO preguntasConRespuesta;
            RespuestaDescripcionDTO respuesta;
            CuestionarioTodoDTO cuestionarioCompleto = new CuestionarioTodoDTO()
            {
                Descripcion = cuestionario.Descripcion
            };
            List<PreguntaConRespuestaDTO> listaPreguntas = new List<PreguntaConRespuestaDTO>();
            
            var lista = Context.Preguntas
                .Include(x => x.CuestionarioNavegator)
                .Include(x => x.RespuestaNavegator)
                .Where(x => x.CuestionarioId == cuestionario.CuestionarioID)
                .ToList();

            foreach(Pregunta preguntas in lista)
            {
                List<RespuestaDescripcionDTO> listaRespuestas = new List<RespuestaDescripcionDTO>();

                foreach (Respuesta respuestas in preguntas.RespuestaNavegator)
                {
                    respuesta = new RespuestaDescripcionDTO()
                    {
                        Descripcion = respuestas.Descripcion,
                        Flag = respuestas.Flag
                    };
                    listaRespuestas.Add(respuesta);
                }
                preguntasConRespuesta = new PreguntaConRespuestaDTO()
                {
                    Descripcion = preguntas.Descripcion,
                    Respuestas = listaRespuestas
                };
                listaPreguntas.Add(preguntasConRespuesta);
            }
            cuestionarioCompleto.Preguntas = listaPreguntas;
            return cuestionarioCompleto;
        }

        public CuestionarioTodoDTO GetCuestionarioConRespuestasCorrectas(Cuestionario cuestionario)
        {
            PreguntaConRespuestaDTO preguntasConRespuesta;
            RespuestaDescripcionDTO respuesta;
            CuestionarioTodoDTO cuestionarioCompleto = new CuestionarioTodoDTO()
            {
                Descripcion = cuestionario.Descripcion
            };
            List<PreguntaConRespuestaDTO> listaPreguntas = new List<PreguntaConRespuestaDTO>();

            var lista = Context.Preguntas
                .Include(x => x.CuestionarioNavegator)
                .Include(x => x.RespuestaNavegator)
                .Where(x => x.CuestionarioId == cuestionario.CuestionarioID)
                .ToList();

            foreach (Pregunta preguntas in lista)
            {
                var listaRespuestas = new List<RespuestaDescripcionDTO>();

                foreach (Respuesta respuestas in preguntas.RespuestaNavegator)
                {
                    if (respuestas.Flag == true)
                    {
                        respuesta = new RespuestaDescripcionDTO()
                        {
                            Descripcion = respuestas.Descripcion,
                            Flag = respuestas.Flag
                        };
                        listaRespuestas.Add(respuesta);
                    }
                }
                preguntasConRespuesta = new PreguntaConRespuestaDTO()
                {
                    Descripcion = preguntas.Descripcion,
                    Respuestas = listaRespuestas
                };
                listaPreguntas.Add(preguntasConRespuesta);
            }
            cuestionarioCompleto.Preguntas = listaPreguntas;
            return cuestionarioCompleto;
        }
    }
}
