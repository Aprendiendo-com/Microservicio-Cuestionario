using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Cuestionario.Domain.Command.BaseRepository;
using Microservicio_Cuestionario.Domain.Command.BaseServices;

namespace Microservicio_Cuestionario.Aplication.Services.Base
{
    public class GenericService : IService
    {
        protected IRepository Repository;

        public GenericService(IRepository repository)
        {
            this.Repository = repository;
        }

        public void Add<T>(T entity) where T : class
        {
            Repository.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            Repository.Delete<T>(entity);
        }

        public void DeleteBy<T>(int id) where T : class
        {
            Repository.DeleteBy<T>(id);
        }

        public T FindBy<T>(int id) where T : class
        {
             return Repository.FindBy<T>(id);
        }

        public List<T> Traer<T>() where T : class
        {
            return Repository.Traer<T>();
        }

        public void Update<T>(T entity) where T : class
        {
            Repository.Update<T>(entity);
        }
    }
}
