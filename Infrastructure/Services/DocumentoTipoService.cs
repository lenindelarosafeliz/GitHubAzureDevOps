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
    public class DocumentoTipoService : IDocumentoTipoService
    {
        private readonly ILogger<IDocumentoTipoService> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public DocumentoTipoService(ILogger<IDocumentoTipoService> logger,
                                       IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(DocumentoTipo entity)
        {
            _unitOfWork.DocumentoTipos.Add(entity);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> AddRangeAsync(IEnumerable<DocumentoTipo> entities)
        {
            _unitOfWork.DocumentoTipos.AddRange(entities);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.DocumentoTipos.CountAsync();
        }

        public async Task<IEnumerable<DocumentoTipo>> FindAsync(Expression<Func<DocumentoTipo, bool>> expression)
        {
            return await _unitOfWork.DocumentoTipos.FindAsync(expression);
        }       

        public async Task<IEnumerable<DocumentoTipo>> GetAllAsync()
        {
            return await _unitOfWork.DocumentoTipos.GetAllAsync();
        }      

        public async Task<DocumentoTipo> GetByIdAsync(int id)
        {
            return await _unitOfWork.DocumentoTipos.GetByIdAsync(id);
        }
      
        public async Task<int> RemoveAsync(DocumentoTipo entity)
        {
            _unitOfWork.DocumentoTipos.Remove(entity);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            _unitOfWork.DocumentoTipos.Remove(id);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> RemoveRageAsync(IEnumerable<DocumentoTipo> entities)
        {
            _unitOfWork.DocumentoTipos.RemoveRange(entities);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> UpdateAsync(int id, DocumentoTipo entity)
        {
            _unitOfWork.DocumentoTipos.Update(id, entity);
            return await _unitOfWork.CompleteAsync();
        }
    }
}