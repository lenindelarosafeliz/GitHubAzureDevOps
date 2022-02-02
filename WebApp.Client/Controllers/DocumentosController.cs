using System;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
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

        //// GET: Documentos/Details/5
        //public IActionResult Details(int id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var documento = _unitOfWork.Documentos.GetById(id);
        //    if (documento == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(documento);
        //}

        //// GET: Documentos/Create
        //public IActionResult Create()
        //{
        //    ViewData["DocumentoTipoId"] = new SelectList(_unitOfWork.DocumentoTipos.GetAll(), "Id", "Id");
        //    ViewData["PersonaId"] = new SelectList(_unitOfWork.Personas.GetAll(), "Id", "Id");
        //    return View();
        //}

        //// POST: Documentos/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Documento documento)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Documentos.Add(documento);
        //        _unitOfWork.Complete();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["DocumentoTipoId"] = new SelectList(_unitOfWork.DocumentoTipos.GetAll(), "Id", "Id", documento.DocumentoTipoId);
        //    ViewData["PersonaId"] = new SelectList(_unitOfWork.Personas.GetAll(), "Id", "Id", documento.PersonaId);
        //    return View(documento);
        //}

        //// GET: Documentos/Edit/5
        //public IActionResult Edit(int id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var documento = _unitOfWork.Documentos.GetById(id);
        //    if (documento == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["DocumentoTipoId"] = new SelectList(_unitOfWork.DocumentoTipos.GetAll(), "Id", "Id", documento.DocumentoTipoId);
        //    ViewData["PersonaId"] = new SelectList(_unitOfWork.Personas.GetAll(), "Id", "Id", documento.PersonaId);
        //    return View(documento);
        //}

        //// POST: Documentos/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, Documento documento)
        //{
        //    if (id != documento.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _unitOfWork.Documentos.Update(id, documento);
        //            _unitOfWork.Complete();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    ViewData["DocumentoTipoId"] = new SelectList(_unitOfWork.DocumentoTipos.GetAll(), "Id", "Id", documento.DocumentoTipoId);
        //    ViewData["PersonaId"] = new SelectList(_unitOfWork.Personas.GetAll(), "Id", "Id", documento.PersonaId);
        //    return View(documento);
        //}

        //// GET: Documentos/Delete/5
        //public IActionResult Delete(int id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var cliente = _unitOfWork.Documentos.GetById(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cliente);
        //}

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
