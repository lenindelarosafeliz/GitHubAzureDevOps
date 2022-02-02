using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Repoitories;
using Domain.Entities;

namespace WebApi.Controllers
{
    public class DocumentosController : BaseController
    {
        private readonly ILogger<DocumentosController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DocumentosController(ILogger<DocumentosController> logger,
                                    IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET: /Documentos
        [HttpGet]
        public IEnumerable<Documento> Get()
        {
            return _unitOfWork.Documentos.GetAll();
        }

        // GET: /Documentos/5
        [HttpGet("{id}")]
        public Documento Get(int id)
        {
            return _unitOfWork.Documentos.GetById(id);
        }

        // POST: Documentos
        [HttpPost]
        public void Post([FromBody] Documento documento)
        {
            _unitOfWork.Documentos.Add(documento);
            _unitOfWork.Complete();
        }

        // PUT: Documentos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Documento documento)
        {
            _unitOfWork.Documentos.Update(id, documento);
            _unitOfWork.Complete();
        }

        // DELETE: Documentos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Documentos.Remove(id);
            _unitOfWork.Complete();
        }
    }
}
