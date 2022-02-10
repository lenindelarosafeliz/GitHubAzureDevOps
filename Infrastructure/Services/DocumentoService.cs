using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

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

        public void Add(Documento entity)
        {
            _unitOfWork.Documentos.Add(entity);
            _unitOfWork.Complete();
        }

        public void AddRange(IEnumerable<Documento> entities)
        {
            throw new NotImplementedException();
        }

        public int Count(Documento entity)
        {
            throw new NotImplementedException();
        }

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Documento> Find(Expression<Func<Documento, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Documento> GetAll()
        {
            return _unitOfWork.Documentos.GetAll();
        }

        public Documento GetById(int id)
        {
            return _unitOfWork.Documentos.GetById(id);
        }

        public void Remove(Documento entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _unitOfWork.Documentos.Remove(id);
            _unitOfWork.Complete();
        }

        public void RemoveRage(IEnumerable<Documento> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Documento entity)
        {
            _unitOfWork.Documentos.Update(id, entity);
            _unitOfWork.Complete();
        }
    }
}