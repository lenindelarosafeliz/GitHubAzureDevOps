using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Services;
using Domain.Entities;

namespace WebApi.Controllers
{
    public class PersonasController : BaseController
    {
        private readonly ILogger<PersonasController> _logger;
        private readonly IPersonaService _personaService;

        public PersonasController(ILogger<PersonasController> logger,
                                  IPersonaService personaService)
        {
            try
            {
                _logger = logger;
                _personaService = personaService;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }      
        
        // GET: /Personas
        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            return _personaService.GetAll();
        }

        // GET: /Personas/5
        [HttpGet("{id}")]
        public Persona Get(int id)
        {
            return _personaService.GetById(id);
        }

        // POST: Personas
        [HttpPost]
        public void Post([FromBody] Persona persona)
        {
            _personaService.Add(persona);
        }

        // PUT: Personas/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Persona persona)
        {
            _personaService.Update(id, persona);
        }

        // DELETE: Personas/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _personaService.Remove(id);
        }
    }
}
