using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Entities;
using Application.Interfaces.Services;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class DocumentosController : BaseController
    {
        private readonly ILogger<DocumentosController> _logger;
        private readonly IDocumentoService _documentoService;

        public DocumentosController(ILogger<DocumentosController> logger,
                                    IDocumentoService documentoService)
        {
            _logger = logger;
            _documentoService = documentoService;
        }

        // GET: /Documentos
        [HttpGet]
        public async Task<IEnumerable<Documento>> Get()
        {
            try
            {
                return await _documentoService.GetAllAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // GET: /Documentos/5
        [HttpGet("{id}")]
        public async Task<Documento> Get(int id)
        {
            try
            {
                return await _documentoService.GetByIdAsync(id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // POST: Documentos
        [HttpPost]
        public async Task<int> Post([FromBody] Documento documento)
        {
            try
            {
                return await _documentoService.AddAsync(documento);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // PUT: Documentos/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody] Documento documento)
        {
            try
            {
                return await _documentoService.UpdateAsync(id, documento);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // DELETE: Documentos/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            try
            {
                return await _documentoService.RemoveAsync(id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
