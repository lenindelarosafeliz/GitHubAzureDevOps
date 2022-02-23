using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<Persona>> Get()
        {
            return await _personaService.GetAllAsync();
        }

        // GET: /Personas/5
        [HttpGet("{id}")]
        public async Task<Persona> Get(int id)
        {
            return await _personaService.GetByIdAsync(id);
        }

        // POST: Personas
        [HttpPost]
        public async Task<int> Post([FromBody] Persona persona)
        {
            return await _personaService.AddAsync(persona);
        }

        // PUT: Personas/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody] Persona persona)
        {
            return await _personaService.UpdateAsync(id, persona);
        }

        // DELETE: Personas/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await _personaService.RemoveAsync(id);
        }
    }
}