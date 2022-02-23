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
    public class DocumentoService : IDocumentoService
    {
        private readonly ILogger<IDocumentoService> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public DocumentoService(ILogger<IDocumentoService> logger,
                                       IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(Documento entity)
        {
            _unitOfWork.Documentos.Add(entity);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> AddRangeAsync(IEnumerable<Documento> entities)
        {
            _unitOfWork.Documentos.AddRange(entities);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.Documentos.CountAsync();
        }

        public async Task<IEnumerable<Documento>> FindAsync(Expression<Func<Documento, bool>> expression)
        {
            return await _unitOfWork.Documentos.FindAsync(expression);
        }

        public async Task<IEnumerable<Documento>> GetAllAsync()
        {
            return await _unitOfWork.Documentos.GetAllAsync(
                includes: new Expression<Func<Documento, object>>[]
                {
                    d=> d.DocumentoTipo,
                    p=> p.Persona
                });
        }

        public async Task<Documento> GetByIdAsync(int id)
        {
            return await _unitOfWork.Documentos.GetByIdAsync(id,
                  includes: new Expression<Func<Documento, object>>[]
                {
                    d=> d.DocumentoTipo,
                    p=> p.Persona
                });
        }

        public async Task<int> RemoveAsync(Documento entity)
        {
            _unitOfWork.Documentos.Remove(entity);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            _unitOfWork.Documentos.Remove(id);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> RemoveRageAsync(IEnumerable<Documento> entities)
        {
            _unitOfWork.Documentos.RemoveRange(entities);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> UpdateAsync(int id, Documento entity)
        {
            _unitOfWork.Documentos.Update(id, entity);
            return await _unitOfWork.CompleteAsync();
        }
    }
}