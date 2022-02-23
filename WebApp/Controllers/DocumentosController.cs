using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return View(_documentoService.GetAllAsync());
        }

        // GET: Documentos/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var documento = _documentoService.GetByIdAsync(id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        // GET: Documentos/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["DocumentoTipoId"] = new SelectList(await _documentoTipoService.GetAllAsync(), "Id", "Descripcion");
            ViewData["PersonaId"] = new SelectList(await _personaService.GetAllAsync(), "Id", "NombreCompleto");
            return View();
        }

        // POST: Documentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Documento documento)
        {
            if (ModelState.IsValid)
            {
                var result = await _documentoService.AddAsync(documento);
                return RedirectToAction(nameof(Index));
            }

            ViewData["DocumentoTipoId"] = new SelectList(await _documentoTipoService.GetAllAsync(), "Id", "Descripcion", documento.DocumentoTipoId);
            ViewData["PersonaId"] = new SelectList(await _personaService.GetAllAsync(), "Id", "NombreCompleto", documento.PersonaId);
            return View(documento);
        }

        // GET: Documentos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var documento = _documentoService.GetByIdAsync(id).Result;
            if (documento == null)
            {
                return NotFound();
            }
            ViewData["DocumentoTipoId"] = new SelectList(await _documentoTipoService.GetAllAsync(), "Id", "Descripcion", documento.DocumentoTipoId);
            ViewData["PersonaId"] = new SelectList(await _personaService.GetAllAsync(), "Id", "NombreCompleto", documento.PersonaId);
            return View(documento);
        }

        // POST: Documentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Documento documento)
        {
            if (id != documento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _documentoService.UpdateAsync(id, documento);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            ViewData["DocumentoTipoId"] = new SelectList(await _documentoTipoService.GetAllAsync(), "Id", "Descripcion", documento.DocumentoTipoId);
            ViewData["PersonaId"] = new SelectList(await _personaService.GetAllAsync(), "Id", "NombreCompleto", documento.PersonaId);
            return View(documento);
        }

        // GET: Documentos/Delete/5
        public async Task<IActionResult>  Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cliente = await _documentoService.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _documentoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public JsonResult GetAllRecords()
        {
            var data = _documentoService.GetAllAsync().Result;
            var output = new { status = "success", total = data.Count(), records = data };

            return Json(output);
        }
    }
}