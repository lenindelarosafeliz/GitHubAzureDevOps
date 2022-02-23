using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public partial class DocumentoTiposController : Controller
    {

        private readonly ILogger<DocumentosController> _logger;
        private readonly IDocumentoTipoService _documentoTipoService;

        public DocumentoTiposController(ILogger<DocumentosController> logger,
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

        public async Task<IActionResult> Index()
        {
            return View(await _documentoTipoService.GetAllAsync());
        }

        // GET: DocumentoTipos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var documento = await _documentoTipoService.GetByIdAsync(id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        // GET: DocumentoTipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocumentoTipos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentoTipo documentoTipo)
        {
            if (ModelState.IsValid)
            {
                var result = await _documentoTipoService.AddAsync(documentoTipo);
                return RedirectToAction(nameof(Index));
            }

            return View(documentoTipo);
        }

        // GET: DocumentoTipos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var documentoTipo = await _documentoTipoService.GetByIdAsync(id);
            if (documentoTipo == null)
            {
                return NotFound();
            }
            return View(documentoTipo);
        }

        // POST: DocumentoTipos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DocumentoTipo documentoTipo)
        {
            if (id != documentoTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _documentoTipoService.UpdateAsync(id, documentoTipo);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(documentoTipo);
        }

        // GET: DocumentoTipos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cliente = await _documentoTipoService.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: DocumentoTipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _documentoTipoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public JsonResult GetAllRecords()
        {
            var data = _documentoTipoService.GetAllAsync().Result;

            //List<Documento> documents = new List<Documento>();
            //foreach (var document in data)
            //{
            //    documents.Add(new Document { Id = document.Id, Description = document.Description, PersonId = document.PersonId, DocumentTypeId = document.DocumentTypeId });
            //}

            var output = new { status = "success", total = data.Count(), records = data };

            return Json(output);
        }


    }
}