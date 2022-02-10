using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Entities;
using Application.Interfaces.Services;

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
        public IEnumerable<Documento> Get()
        {
            try
            {
                return _documentoService.GetAll();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // GET: /Documentos/5
        [HttpGet("{id}")]
        public Documento Get(int id)
        {
            try
            {
                return _documentoService.GetById(id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // POST: Documentos
        [HttpPost]
        public void Post([FromBody] Documento documento)
        {
            try
            {
                _documentoService.Add(documento);               
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // PUT: Documentos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Documento documento)
        {
            try
            {
                _documentoService.Update(id, documento);               
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // DELETE: Documentos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _documentoService.Remove(id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
