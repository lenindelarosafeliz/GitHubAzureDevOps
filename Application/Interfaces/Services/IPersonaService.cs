using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;
namespace Application.Interfaces.Services
{
    public interface IPersonaService
    {
        IEnumerable<Persona> GetAll();
        Persona GetById(int id);
        IEnumerable<Persona> Find(Expression<Func<Persona, bool>> expression);
        void Add(Persona entity);
        void AddRange(IEnumerable<Persona> entities);
        void Remove(Persona entity);
        bool Exist(int id);
        int Count(Persona entity);
        void Remove(int id);
        void Update(int i, Persona entity);
        void RemoveRage(IEnumerable<Persona> entities);
    }
}
