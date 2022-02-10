using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Services;

namespace WebApp.Controllers
{
    public partial class DocumentosController : Controller
    {

        private readonly ILogger<DocumentosController> _logger;
        private readonly IDocumentoService _documentoService;
        private readonly IDocumentoTipoService _documentoTipoService;
        private readonly IPersonaService _personaService;

        public DocumentosController(ILogger<DocumentosController> logger,
                                    IDocumentoService documentoService,
                                    IDocumentoTipoService documentoTipoService,
                                    IPersonaService personaService)
        {
            try
            {
                _logger = logger;
                _documentoService = documentoService;
                _documentoTipoService = documentoTipoService;
                _personaService = personaService;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public IActionResult Index()
        {
            return View(_documentoService.GetAll());
        }

        // GET: Documentos/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var documento = _documentoService.GetById(id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        // GET: Documentos/Create
        public IActionResult Create()
        {
            ViewData["DocumentoTipoId"] = new SelectList(_documentoTipoService.GetAll(), "Id", "Id");
            ViewData["PersonaId"] = new SelectList(_personaService.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Documentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Documento documento)
        {
            if (ModelState.IsValid)
            {
                _documentoService.Add(documento);
                return RedirectToAction(nameof(Index));
            }

            ViewData["DocumentoTipoId"] = new SelectList(_documentoTipoService.GetAll(), "Id", "Id", documento.DocumentoTipoId);
            ViewData["PersonaId"] = new SelectList(_personaService.GetAll(), "Id", "Id", documento.PersonaId);
            return View(documento);
        }

        // GET: Documentos/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var documento = _documentoService.GetById(id);
            if (documento == null)
            {
                return NotFound();
            }
            ViewData["DocumentoTipoId"] = new SelectList(_documentoTipoService.GetAll(), "Id", "Id", documento.DocumentoTipoId);
            ViewData["PersonaId"] = new SelectList(_personaService.GetAll(), "Id", "Id", documento.PersonaId);
            return View(documento);
        }

        // POST: Documentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Documento documento)
        {
            if (id != documento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _documentoService.Update(id, documento);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            ViewData["DocumentoTipoId"] = new SelectList(_documentoTipoService.GetAll(), "Id", "Id", documento.DocumentoTipoId);
            ViewData["PersonaId"] = new SelectList(_personaService.GetAll(), "Id", "Id", documento.PersonaId);
            return View(documento);
        }

        // GET: Documentos/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cliente = _documentoService.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _documentoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}