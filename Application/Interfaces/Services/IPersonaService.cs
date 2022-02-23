using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Interfaces.Services
{
    public interface IPersonaService
    {
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<Persona> GetByIdAsync(int id);
        Task<IEnumerable<Persona>> FindAsync(Expression<Func<Persona, bool>> expression);
        Task<int> AddAsync(Persona entity);
        Task<int> AddRangeAsync(IEnumerable<Persona> entities);
        Task<int> CountAsync();
        Task<int> RemoveAsync(Persona entity);
        Task<int> RemoveAsync(int id);
        Task<int> UpdateAsync(int id, Persona entity);
        Task<int> RemoveRageAsync(IEnumerable<Persona> entities);
    }
}