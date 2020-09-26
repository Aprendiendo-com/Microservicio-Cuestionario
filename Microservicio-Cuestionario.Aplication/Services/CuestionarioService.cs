using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microservicio_Cuestionario.Aplication.Services.Base;
using Microservicio_Cuestionario.Domain.DTO;
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

            var cuestionarioDb = Repository.Add(cuestionario);

            return this._mapper.Map<CuestionarioRespuestaDTO>(cuestionarioDb);
        }

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
                Calificacion = cuestionarioDTO.Calificacion,
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
                    cuestionarioDTO.Calificacion = cuestionario.Calificacion;

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
