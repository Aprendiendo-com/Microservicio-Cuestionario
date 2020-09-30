using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microservicio_Cuestionario.Aplication.Services.Base;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.RegistrosDTO.ResquestDTO;
using Microservicio_Cuestionario.Domain.Entities;
using Microservicio_Cuestionario.Domain.Queries;
using Microservicio_Cuestionario.Domain.Services;

namespace Microservicio_Cuestionario.Aplication.Services
{
    public class RegistroService : GenericService, IRegistroService
    {
        public RegistroService(IRegistroRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public RegistroRespuestaDTO AddRegistro(RegistroAddDTO  registroAddDTO)
        {
            var registro = this._mapper.Map<Registro>(registroAddDTO);

            Repository.Add(registro);


            return this._mapper.Map<RegistroRespuestaDTO>(registro);
        }
        public List<RegistroDTO> GetAll()
        {
            var registros = this.Repository.Traer<Domain.Entities.Registro>();

            var dto = this._mapper.Map<List<RegistroDTO>>(registros);

            return dto;
        }

        //public void Update(RegistroDTO registroDTO)// crear un dto para actualizar un registro
        //{
        //    var registro = new Domain.Entities.Registro()
        //    {
        //        EstudianteId = registroDTO.EstudianteId,
        //        CuestionarioId = registroDTO.CuestionarioId
        //    };
        //    this.Repository.Update(registro);
        //}

        //public void DeleteRegistroById(int id)
        //{
        //    // aca podes hacer esto simplemente

        //    //this.Repository.DeleteBy<Registro>(id);    hace lo mismo que esta abajo

        //    var registros = this.Repository.Traer<Domain.Entities.Registro>();

        //    foreach (var registro in registros)
        //    {
        //        if (registro.RegistroId == id)
        //        {
        //            this.Repository.Delete(registro);
        //        }
        //    }
        //}
    }
}
