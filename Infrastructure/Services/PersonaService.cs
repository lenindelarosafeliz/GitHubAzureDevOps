using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

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

        public void Add(Persona entity)
        {
            _unitOfWork.Personas.Add(entity);
            _unitOfWork.Complete();
        }

        public void AddRange(IEnumerable<Persona> entities)
        {
            throw new NotImplementedException();
        }

        public int Count(Persona entity)
        {
            throw new NotImplementedException();
        }

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Persona> Find(Expression<Func<Persona, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Persona> GetAll()
        {
            return _unitOfWork.Personas.GetAll();
        }

        public Persona GetById(int id)
        {
            return _unitOfWork.Personas.GetById(id);
        }

        public void Remove(Persona entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _unitOfWork.Personas.Remove(id);
            _unitOfWork.Complete();
        }

        public void RemoveRage(IEnumerable<Persona> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Persona entity)
        {
            _unitOfWork.Personas.Update(id, entity);
            _unitOfWork.Complete();
        }
    }
}