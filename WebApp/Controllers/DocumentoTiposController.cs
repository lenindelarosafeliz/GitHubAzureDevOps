using System;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Repoitories;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers
{
    public class DocumentoTiposController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DocumentoTiposController> _logger;
        public DocumentoTiposController(IUnitOfWork unitOfWork,
                                        ILogger<DocumentoTiposController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.DocumentoTipos.GetAll());
        }

        // GET: DocumentoTipos/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var documento = _unitOfWork.DocumentoTipos.GetById(id);
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
                _unitOfWork.DocumentoTipos.Add(documentoTipo);
                _unitOfWork.Complete();
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

            var documento = _unitOfWork.DocumentoTipos.GetById(id);
            if (documento == null)
            {
                return NotFound();
            }
            return View(documento);
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
                    _unitOfWork.DocumentoTipos.Update(id, documentoTipo);
                    _unitOfWork.Complete();
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

            var cliente = _unitOfWork.DocumentoTipos.GetById(id);
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
            _unitOfWork.DocumentoTipos.Remove(id);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
    }
}
