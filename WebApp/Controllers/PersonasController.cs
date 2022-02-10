using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Services;

namespace WebApp.Controllers
{
    public partial class PersonasController : Controller
    {

        private readonly ILogger<PersonasController> _logger;
        private readonly IPersonaService _personaService;

        public PersonasController(ILogger<PersonasController> logger,
                                  IPersonaService personaService)
        {
            try
            {
                _logger = logger;
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
            return View(_personaService.GetAll());
        }

        // GET: Personas/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var persona = _personaService.GetById(id);
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
                _personaService.Add(persona);
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

            var persona = _personaService.GetById(id);
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
                    _personaService.Update(id, persona);

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

            var cliente = _personaService.GetById(id);
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
            _personaService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
