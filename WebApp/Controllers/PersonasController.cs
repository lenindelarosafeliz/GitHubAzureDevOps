using System;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Repoitories;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers
{
    public class PersonasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PersonasController> _logger;
        public PersonasController(IUnitOfWork unitOfWork,
                                  ILogger<PersonasController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Personas.GetAll());
        }

        // GET: Personas/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var persona = _unitOfWork.Personas.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Personas.Add(persona);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Personas/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var persona = _unitOfWork.Personas.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Persona persona)
        {
            if (id != persona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Personas.Update(id, persona);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cliente = _unitOfWork.Personas.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.Personas.Remove(id);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
    }
}
