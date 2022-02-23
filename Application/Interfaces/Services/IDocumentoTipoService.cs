using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IDocumentoTipoService
    {
        Task<IEnumerable<DocumentoTipo>> GetAllAsync();
        Task<DocumentoTipo> GetByIdAsync(int id);
        Task<IEnumerable<DocumentoTipo>> FindAsync(Expression<Func<DocumentoTipo, bool>> expression);
        Task<int> AddAsync(DocumentoTipo entity);
        Task<int> AddRangeAsync(IEnumerable<DocumentoTipo> entities);
        Task<int> RemoveAsync(DocumentoTipo entity);
        Task<int> CountAsync();
        Task<int> RemoveAsync(int id);
        Task<int> UpdateAsync(int i, DocumentoTipo entity);
        Task<int> RemoveRageAsync(IEnumerable<DocumentoTipo> entities);
    }
}
