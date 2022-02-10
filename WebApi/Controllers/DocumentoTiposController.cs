using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Entities;
using Application.Interfaces.Services;

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
        public IEnumerable<DocumentoTipo> Get()
        {
            try
            {
                return _documentoTipoService.GetAll();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // GET: /DocumentoTipos/5
        [HttpGet("{id}")]
        public DocumentoTipo Get(int id)
        {
            try
            {
                return _documentoTipoService.GetById(id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // POST: DocumentoTipos
        [HttpPost]
        public void Post([FromBody] DocumentoTipo documentoTipos)
        {
            try
            {
                _documentoTipoService.Add(documentoTipos);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // PUT: DocumentoTipos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DocumentoTipo documentoTipos)
        {
            try
            {
                _documentoTipoService.Update(id, documentoTipos);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // DELETE: DocumentoTipos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _documentoTipoService.Remove(id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}