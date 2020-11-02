using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AutoMapper;
using Microservicio_Cuestionario.Aplication.Services.Base;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.CuestionariosDTO.DTORequest;
using Microservicio_Cuestionario.Domain.DTO.DTO_Compuestos;
using Microservicio_Cuestionario.Domain.DTO.DTOResponse;
using Microservicio_Cuestionario.Domain.Entities;
using Microservicio_Cuestionario.Domain.Queries;
using Microservicio_Cuestionario.Domain.Services;

namespace Microservicio_Cuestionario.Aplication.Services
{
    public class CuestionarioService : GenericService, ICuestionarioService
    {
        private readonly ICuestionarioRepository repository;
        public CuestionarioService(ICuestionarioRepository repository, IMapper mapper):base(repository, mapper)
        {
            this.repository = repository;
        }
        
        public CuestionarioRespuestaDTO AddCuestionario(CuestionarioDTO cuestionarioDTO)
        {
            var cuestionario = this._mapper.Map<Cuestionario>(cuestionarioDTO);
            
            Repository.Add(cuestionario);

            return this._mapper.Map<CuestionarioRespuestaDTO>(cuestionario);
        }



        //Modificado
        public CuestionarioRespuestaDTO AddCuestionario(CuestionarioTodoDTO cuestionarioTodoDTO)
        {
            var cuestionarioDb = new Cuestionario()
            {
                Descripcion = cuestionarioTodoDTO.Descripcion,
                ClaseId = cuestionarioTodoDTO.ClaseId
            };
            this.Repository.Add(cuestionarioDb);

            var listPreguntas = cuestionarioTodoDTO.Preguntas.ToList();
            
            foreach (var p in listPreguntas)
            {
                var preguntaDb = new Pregunta()
                {
                    CuestionarioId = cuestionarioDb.CuestionarioID,
                    Descripcion = p.Descripcion
                };
                this.Repository.Add(preguntaDb);

                var listRespuestas = p.Respuestas;

                foreach (var r in listRespuestas)
                {
                    var respuestaDb = new Respuesta()
                    {
                        Descripcion = r.Descripcion,
                        Flag = r.Flag,
                        PreguntaId = preguntaDb.PreguntaId
                    };

                    this.Repository.Add(respuestaDb);
                }
            }

            return this._mapper.Map<CuestionarioRespuestaDTO>(cuestionarioDb);
        }
        
        //end

        public List<CuestionarioGetDTO> GetAll()
        {
            var cuestionarios = this.Repository.Traer<Cuestionario>();

            var cuestionariosDTO = this._mapper.Map<List<CuestionarioGetDTO>>(cuestionarios);

            return cuestionariosDTO;
        }

        public void Update(CuestionarioUpdateDTO cuestionarioUpdateDTO)
        {
            var cuestionario = this._mapper.Map<Cuestionario>(cuestionarioUpdateDTO);

            this.Repository.Update(cuestionario);
        }



        //MODIFICADO CUESTIONARIO COMPLETO
        public List<CuestionarioTodoDTO> GetCompleto()
        {
            List<CuestionarioTodoDTO> cuestionariosCompletos = new List<CuestionarioTodoDTO>();
            var cuestionarios = this.Repository.Traer<Cuestionario>();
            foreach (Cuestionario cuestionario in cuestionarios)
            {
                cuestionariosCompletos.Add(repository.GetCuestionarioCompleto(cuestionario));
            }
            return cuestionariosCompletos;
        }
        public List<CuestionarioTodoDTO> GetCompletoConRespuestasCorrectas()
        {
            List<CuestionarioTodoDTO> cuestionariosCompletos = new List<CuestionarioTodoDTO>();
            var cuestionarios = this.Repository.Traer<Cuestionario>();
            foreach (Cuestionario cuestionario in cuestionarios)
            {
                cuestionariosCompletos.Add(repository.GetCuestionarioConRespuestasCorrectas(cuestionario));
            }
            return cuestionariosCompletos;
        }
        //GET CUESTIONARIO POR CLASE
        public CuestionarioTodoDTO GetCuestionarioDeClase(int idClase)
        {
            CuestionarioTodoDTO cuestionarioCompleto = new CuestionarioTodoDTO();
            var cuestionario = this.Repository.Traer<Cuestionario>().FirstOrDefault(x => x.ClaseId == idClase);
            cuestionarioCompleto = repository.GetCuestionarioCompleto(cuestionario);
            return cuestionarioCompleto;
        }
        //Modificado

        public void DeleteCuestionario(CuestionarioDTO cuestionarioDTO)
        { //Se crea un cuestionario con el DTO recibido y lo borra
            var cuestionario = new Domain.Entities.Cuestionario()
            {
                Descripcion = cuestionarioDTO.Descripcion
            };
            this.Repository.Delete(cuestionario);
        }
        public CuestionarioDTO FindCuestionarioById (int id)
        {
            var cuestionarios = this.Repository.Traer<Domain.Entities.Cuestionario>();

            var cuestionarioDTO = new CuestionarioDTO();

            foreach (var cuestionario in cuestionarios)
            {
                if (cuestionario.CuestionarioID == id) {

                    cuestionarioDTO.Descripcion = cuestionario.Descripcion;

                }
            }
            return cuestionarioDTO;
        }

        public void DeleteCuestionarioById(int id)
        {
            var cuestionarios = this.Repository.Traer<Domain.Entities.Cuestionario>();

            foreach (var cuestionario in cuestionarios)
            {
                if (cuestionario.CuestionarioID == id)
                {
                    this.Repository.Delete(cuestionario);
                }
            }
        }

        public CuestionarioCorreccionDTO CorreccionCuestionario(CuestionarioACorregirDTO cuestionario)
        {

            var RespuestasCorrectas = ((ICuestionarioRepository)Repository).RespuestasCorrectas(cuestionario.CuestionarioId);

            var RespuestasAlumnos = cuestionario.Respuestas.ToArray();

            var list = new List<RespuestaCompuestaDTO>();

            int cont = 0;
            double calificacion = 0;
            double calificacionParcial = 0;

            foreach (var r in RespuestasCorrectas)
            {
                
                if (r.Descripcion == RespuestasAlumnos[cont].Descripcion)
                {
                    calificacion += 10.0 / RespuestasCorrectas.Count; 
                    calificacionParcial = 10.0 / RespuestasCorrectas.Count;
                }

                var respuesta = new RespuestaCompuestaDTO()
                {
                    RespuestaAlumno = RespuestasAlumnos[cont].Descripcion,
                    RespuestaCorrecta = r.Descripcion,
                    CalificacionParcial = calificacionParcial
                };
                    
                list.Add(respuesta);

                cont++;
                calificacionParcial = 0;
            }

            return new CuestionarioCorreccionDTO { CalificacionTotal = calificacion, Respuestas = list};
        }


        //MODIFICAOD
        public CuestionarioCorreccionDTO ResolucionCuestionario(CuestionarioAResolver cuestionario)
        {
            var idCuestionario = repository.Traer<Cuestionario>().FirstOrDefault(x => x.ClaseId == cuestionario.ClaseId).CuestionarioID;
            var RespuestasCorrectas = ((ICuestionarioRepository)Repository).RespuestasCorrectas(idCuestionario);

            var RespuestasAlumnos = cuestionario.Respuestas.ToArray();

            var list = new List<RespuestaCompuestaDTO>();

            int cont = 0;
            double calificacion = 0;
            double calificacionParcial = 0;

            foreach (var r in RespuestasCorrectas)
            {

                if (r.Descripcion == RespuestasAlumnos[cont].Descripcion)
                {
                    calificacion += 10.0 / RespuestasCorrectas.Count;
                    calificacionParcial = 10.0 / RespuestasCorrectas.Count;
                }

                var respuesta = new RespuestaCompuestaDTO()
                {
                    RespuestaAlumno = RespuestasAlumnos[cont].Descripcion,
                    RespuestaCorrecta = r.Descripcion,
                    CalificacionParcial = calificacionParcial
                };

                list.Add(respuesta);

                cont++;
                calificacionParcial = 0;
            }
            return new CuestionarioCorreccionDTO { CalificacionTotal = Math.Round(calificacion, 2), Respuestas = list };
        }
    }
}
