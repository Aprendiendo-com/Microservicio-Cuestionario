using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AutoMapper;
using Microservicio_Cuestionario.Aplication.Services.Base;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.CuestionariosDTO.DTORequest;
using Microservicio_Cuestionario.Domain.DTO.DTOResponse;
using Microservicio_Cuestionario.Domain.Entities;
using Microservicio_Cuestionario.Domain.Queries;
using Microservicio_Cuestionario.Domain.Services;

namespace Microservicio_Cuestionario.Aplication.Services
{
    public class CuestionarioService : GenericService, ICuestionarioService
    {
        public CuestionarioService(ICuestionarioRepository repository, IMapper mapper):base(repository, mapper)
        {

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
            };
            var id = this.Repository.Add(cuestionarioDb);
            var listPreguntas = cuestionarioTodoDTO.PreguntaNavegator.ToList();
            
            foreach (var p in listPreguntas)
            {
                var preguntaDb = new Pregunta()
                {
                    CuestionarioId = id.CuestionarioID,
                    Descripcion = p.Descripcion
                };
                var pregunta = this.Repository.Add(preguntaDb);
                var respuestaDb = new Respuesta()
                {
                    PreguntaId = pregunta.PreguntaId,
                    Descripcion = p.RespuestaNavegator.Descripcion
                };
                this.Repository.Add(respuestaDb);
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
    }
}
