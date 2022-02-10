using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

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

        public void Add(DocumentoTipo entity)
        {
            _unitOfWork.DocumentoTipos.Add(entity);
            _unitOfWork.Complete();
        }

        public void AddRange(IEnumerable<DocumentoTipo> entities)
        {
            throw new NotImplementedException();
        }

        public int Count(DocumentoTipo entity)
        {
            throw new NotImplementedException();
        }

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentoTipo> Find(Expression<Func<DocumentoTipo, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentoTipo> GetAll()
        {
            return _unitOfWork.DocumentoTipos.GetAll();
        }

        public DocumentoTipo GetById(int id)
        {
            return _unitOfWork.DocumentoTipos.GetById(id);
        }

        public void Remove(DocumentoTipo entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _unitOfWork.DocumentoTipos.Remove(id);
            _unitOfWork.Complete();
        }

        public void RemoveRage(IEnumerable<DocumentoTipo> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, DocumentoTipo entity)
        {
            _unitOfWork.DocumentoTipos.Update(id, entity);
            _unitOfWork.Complete();
        }
    }
}
