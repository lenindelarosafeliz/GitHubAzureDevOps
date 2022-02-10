using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IDocumentoService
    {
        IEnumerable<Documento> GetAll();
        Documento GetById(int id);
        IEnumerable<Documento> Find(Expression<Func<Documento, bool>> expression);
        void Add(Documento entity);
        void AddRange(IEnumerable<Documento> entities);
        void Remove(Documento entity);
        bool Exist(int id);
        int Count(Documento entity);
        void Remove(int id);
        void Update(int i, Documento entity);
        void RemoveRage(IEnumerable<Documento> entities);
    }
}
