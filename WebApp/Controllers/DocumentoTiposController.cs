using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Services;

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

        public IActionResult Index()
        {
            return View(_documentoTipoService.GetAll());
        }

        // GET: DocumentoTipos/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var documento = _documentoTipoService.GetById(id);
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
        public IActionResult Create(DocumentoTipo documentoTipo)
        {
            if (ModelState.IsValid)
            {
                _documentoTipoService.Add(documentoTipo);
                return RedirectToAction(nameof(Index));
            }

            return View(documentoTipo);
        }

        // GET: DocumentoTipos/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var documentoTipo = _documentoTipoService.GetById(id);
            if (documentoTipo == null)
            {
                return NotFound();
            }
            return View(documentoTipo);
        }

        // POST: DocumentoTipos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DocumentoTipo documentoTipo)
        {
            if (id != documentoTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _documentoTipoService.Update(id, documentoTipo);

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
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cliente = _documentoTipoService.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: DocumentoTipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _documentoTipoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}