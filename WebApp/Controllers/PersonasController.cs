using System;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public async Task<IActionResult> Index()
        {
            return View( await _personaService.GetAllAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var persona = await _personaService.GetByIdAsync(id);
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
        public async Task<IActionResult> Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                var result = await _personaService.AddAsync(persona);
                return RedirectToAction(nameof(Index));
            }

            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var persona = await _personaService.GetByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Persona persona)
        {
            if (id != persona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _personaService.UpdateAsync(id, persona);
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
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cliente = await _personaService.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _personaService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(string request)
        {
            dynamic response = JsonConvert.DeserializeObject(request);

            Persona input = response.ToObject<Persona>();

            try
            {
                if (input.Id != 0)
                {
                    var result = await _personaService.UpdateAsync(input.Id, input);
                    return Json(new { status = "success" });
                }

                else
                {
                    var person = new Persona
                    {
                        Nombre = input.Nombre,
                        Apellido = input.Apellido,
                        FechaNacimiento = input.FechaNacimiento
                    };
                    var result = await _personaService.AddAsync(input);
                    return Json(new { status = "success" });
                }
            }
            catch
            {
                return Json(new { status = "error", message = "La operación no ha podido realizarse debido a un error en el servidor." });
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var result = await _personaService.RemoveAsync(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { status = "error", message = $"Ha ocurrido un error al realizar la operación. {ex}" });
        //    }
        //}


        [HttpGet]
        public JsonResult GetAllRecords()
        {
            var data = _personaService.GetAllAsync().Result;
            var output = new { status = "success", total = data.Count(), records = data };
            return Json(output);
        }
    }
}
