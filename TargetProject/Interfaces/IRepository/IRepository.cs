using System.Collections.Generic;
using TargetProject.Models;

namespace TargetProject.Interfaces.IRepository
{
    public interface IRepository <T> where T : Entity 
    {
        void Add(T entity);
        void Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
        void Update(T newEntity);    
    }
}
