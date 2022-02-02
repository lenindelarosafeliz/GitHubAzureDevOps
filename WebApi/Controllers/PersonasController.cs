using Application.Interfaces.Repoitories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class PersonasController : BaseController
    {
        private readonly ILogger<PersonasController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public PersonasController(ILogger<PersonasController> logger,
                                    IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        
        // GET: /Personas
        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            return _unitOfWork.Personas.GetAll();
        }

        // GET: /Personas/5
        [HttpGet("{id}")]
        public Persona Get(int id)
        {
            return _unitOfWork.Personas.GetById(id);
        }

        // POST: Personas
        [HttpPost]
        public void Post([FromBody] Persona persona)
        {
            _unitOfWork.Personas.Add(persona);
            _unitOfWork.Complete();
        }

        // PUT: Personas/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Persona persona)
        {
            _unitOfWork.Personas.Update(id, persona);
            _unitOfWork.Complete();
        }

        // DELETE: Personas/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Personas.Remove(id);
            _unitOfWork.Complete();
        }
    }
}
