using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly ILogger<IPersonaService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public PersonaService(ILogger<IPersonaService> logger,
                                       IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(Persona entity)
        {
            _unitOfWork.Personas.Add(entity);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> AddRangeAsync(IEnumerable<Persona> entities)
        {
            _unitOfWork.Personas.AddRange(entities);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.Personas.CountAsync();
        }

        public async Task<IEnumerable<Persona>> FindAsync(Expression<Func<Persona, bool>> expression)
        {
          return await  _unitOfWork.Personas.FindAsync(expression);
          
        }

        public async  Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _unitOfWork.Personas.GetAllAsync();
        }
        
        public async Task<Persona> GetByIdAsync(int id)
        {
            return await _unitOfWork.Personas.GetByIdAsync(id);
        }

        public async Task<int> RemoveAsync(Persona entity)
        {
            _unitOfWork.Personas.Remove(entity);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            _unitOfWork.Personas.Remove(id);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> RemoveRageAsync(IEnumerable<Persona> entities)
        {
            _unitOfWork.Personas.RemoveRange(entities);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> UpdateAsync(int id, Persona entity)
        {
            _unitOfWork.Personas.Update(id, entity);
            return await _unitOfWork.CompleteAsync();
        }
    }
}