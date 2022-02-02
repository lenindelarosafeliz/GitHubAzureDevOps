using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Repoitories;
using Domain.Entities;

namespace WebApi.Controllers
{
    public class DocumentoTiposController : BaseController
    {
        private readonly ILogger<DocumentoTiposController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DocumentoTiposController(ILogger<DocumentoTiposController> logger,
                                    IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        
        // GET: /DocumentoTipos
        [HttpGet]
        public IEnumerable<DocumentoTipo> Get()
        {
            return _unitOfWork.DocumentoTipos.GetAll();
        }

        // GET: /DocumentoTipos/5
        [HttpGet("{id}")]
        public DocumentoTipo Get(int id)
        {
            return _unitOfWork.DocumentoTipos.GetById(id);
        }

        // POST: DocumentoTipos
        [HttpPost]
        public void Post([FromBody] DocumentoTipo documentoTipos)
        {
            _unitOfWork.DocumentoTipos.Add(documentoTipos);
            _unitOfWork.Complete();
        }

        // PUT: DocumentoTipos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DocumentoTipo documentoTipos)
        {
            _unitOfWork.DocumentoTipos.Update(id, documentoTipos);
            _unitOfWork.Complete();
        }

        // DELETE: DocumentoTipos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.DocumentoTipos.Remove(id);
            _unitOfWork.Complete();
        }
    }
}
