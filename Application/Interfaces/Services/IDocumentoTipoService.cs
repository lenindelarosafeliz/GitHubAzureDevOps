using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IDocumentoTipoService
    {
        IEnumerable<DocumentoTipo> GetAll();
        DocumentoTipo GetById(int id);
        IEnumerable<DocumentoTipo> Find(Expression<Func<DocumentoTipo, bool>> expression);
        void Add(DocumentoTipo entity);
        void AddRange(IEnumerable<DocumentoTipo> entities);
        void Remove(DocumentoTipo entity);
        bool Exist(int id);
        int Count(DocumentoTipo entity);
        void Remove(int id);
        void Update(int i, DocumentoTipo entity);
        void RemoveRage(IEnumerable<DocumentoTipo> entities);
    }
}
