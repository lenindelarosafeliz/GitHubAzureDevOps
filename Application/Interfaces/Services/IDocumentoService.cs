using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IDocumentoService
    {
        Task<IEnumerable<Documento>> GetAllAsync();
        Task<Documento> GetByIdAsync(int id);
        Task<IEnumerable<Documento>> FindAsync(Expression<Func<Documento, bool>> expression);
        Task<int> AddAsync(Documento entity);
        Task<int> AddRangeAsync(IEnumerable<Documento> entities);
        Task<int> CountAsync();
        Task<int> RemoveAsync(Documento entity);
        Task<int> RemoveAsync(int id);
        Task<int> UpdateAsync(int i, Documento entity);
        Task<int> RemoveRageAsync(IEnumerable<Documento> entities);
    }
}