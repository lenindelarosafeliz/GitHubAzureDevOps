using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Domain.Entities;
using WebApp.Client.Services;

namespace WebApp.Client.Controllers
{
    public partial class DocumentosController : Controller
    {
        private readonly ILogger<DocumentosController> _logger;
        public DocumentosController(ILogger<DocumentosController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ApiService apiService = new ApiService();
                var response = await apiService.GetList<Documento>("https://localhost:44327", "/documentos");
                              
                if (response.IsSuccess)
                {
                    return View(response.Result);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        // GET: Documentos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            ApiService apiService = new ApiService();
            var documento  = await apiService.Get<Documento>("https://localhost:44327", "/documentos",id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento.Result);
        }

        // GET: Documentos/Create
        public async Task<IActionResult> Create()
        {
            ApiService apiService = new ApiService();
            var documentoTipos = await apiService.GetList<DocumentoTipo>("https://localhost:44327", "/documentoTipos");
            var personas = await apiService.GetList<Persona>("https://localhost:44327", "/personas");

            ViewData["DocumentoTipoId"] = new SelectList((List<DocumentoTipo>)documentoTipos.Result, "Id", "Descripcion");
            ViewData["PersonaId"] = new SelectList((List<Persona>)personas.Result, "Id", "NombreCompleto");
            return View();
        }

        // POST: Documentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Documento documento)
        {
            ApiService apiService = new ApiService();

            var documentoTipos = await apiService.GetList<DocumentoTipo>("https://localhost:44327", "/documentoTipos");
            var personas = await apiService.GetList<Persona>("https://localhost:44327", "/personas");

            if (ModelState.IsValid)
            {
                var insert = await apiService.Post<Documento>("https://localhost:44327", "/documentos",documento);
                return RedirectToAction(nameof(Index));
            }

            ViewData["DocumentoTipoId"] = new SelectList((List<DocumentoTipo>)documentoTipos.Result, "Id", "Descripcion", documento.DocumentoTipoId);
            ViewData["PersonaId"] = new SelectList((List<Persona>)personas.Result, "Id", "NombreCompleto", documento.PersonaId);
            return View(documento);
        }

        // GET: Documentos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ApiService apiService = new ApiService();

            var documentoTipos = await apiService.GetList<DocumentoTipo>("https://localhost:44327", "/documentoTipos");
            var personas = await apiService.GetList<Persona>("https://localhost:44327", "/personas");

            if (id == 0)
            {
                return NotFound();
            }

            var documento = await apiService.Get<Documento>("https://localhost:44327", "/documentos", id);
            if (documento == null)
            {
                return NotFound();
            }
            ViewData["DocumentoTipoId"] = new SelectList((List<DocumentoTipo>)documentoTipos.Result, "Id", "Descripcion", ((Documento)(documento.Result)).DocumentoTipoId);
            ViewData["PersonaId"] = new SelectList((List<Persona>)personas.Result, "Id", "NombreCompleto", ((Documento)(documento.Result)).PersonaId );
            return View(documento.Result);
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

            ApiService apiService = new ApiService();

            var documentoTipos = await apiService.GetList<DocumentoTipo>("https://localhost:44327", "/documentoTipos");
            var personas = await apiService.GetList<Persona>("https://localhost:44327", "/personas");

            if (ModelState.IsValid)
            {
                try
                {

                    var update = await apiService.Put<Documento>("https://localhost:44327", "/documentos", documento);
                    //_unitOfWork.Documentos.Update(id, documento);
                    //_unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            ViewData["DocumentoTipoId"] = new SelectList((List<DocumentoTipo>)documentoTipos.Result, "Id", "Descripcion", documento.DocumentoTipoId);
            ViewData["PersonaId"] = new SelectList((List<Persona>)personas.Result, "Id", "NombreCompleto", documento.PersonaId);
            return View(documento);
        }

        // GET: Documentos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            ApiService apiService = new ApiService();
            var documento = await apiService.Get<Documento>("https://localhost:44327", "/documentos", id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento.Result);
        }

        //// POST: Documentos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    _unitOfWork.Documentos.Remove(id);
        //    _unitOfWork.Complete();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
