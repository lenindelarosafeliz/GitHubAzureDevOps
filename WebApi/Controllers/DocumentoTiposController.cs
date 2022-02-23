using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Entities;
using Application.Interfaces.Services;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class DocumentoTiposController : BaseController
    {
        private readonly ILogger<DocumentoTiposController> _logger;
        private readonly IDocumentoTipoService _documentoTipoService;

        public DocumentoTiposController(ILogger<DocumentoTiposController> logger,
                                        IDocumentoTipoService documentoTipoService)
        {
            try
            {
                _logger = logger;
                _documentoTipoService = documentoTipoService;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // GET: /DocumentoTipos
        [HttpGet]
        public async Task<IEnumerable<DocumentoTipo>> Get()
        {
            try
            {
                return await _documentoTipoService.GetAllAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // GET: /DocumentoTipos/5
        [HttpGet("{id}")]
        public async Task<DocumentoTipo> Get(int id)
        {
            try
            {
                return await _documentoTipoService.GetByIdAsync(id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // POST: DocumentoTipos
        [HttpPost]
        public async Task<int> Post([FromBody] DocumentoTipo documentoTipos)
        {
            try
            {
                return await _documentoTipoService.AddAsync(documentoTipos);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // PUT: DocumentoTipos/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody] DocumentoTipo documentoTipos)
        {
            try
            {
                return await _documentoTipoService.UpdateAsync(id, documentoTipos);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // DELETE: DocumentoTipos/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            try
            {
                return await _documentoTipoService.RemoveAsync(id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}