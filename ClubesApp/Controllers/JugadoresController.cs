
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubesApp.Models;

namespace ClubesApp.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly ClubesAppContext _context;

        public JugadoresController(ClubesAppContext context)
        {
            _context = context;
        }

        // Llena la lista desplegable con los nombres de los clubes
        private void CargarClubes(int? clubSeleccionado = null)
        {
            ViewData["ClubId"] = new SelectList(
                _context.Club.OrderBy(c => c.Nombre), "Id", "Nombre", clubSeleccionado);
        }

        // GET: Jugadores
        public async Task<IActionResult> Index()
        {
            var jugadores = _context.Jugador.Include(j => j.Club);
            return View(await jugadores.ToListAsync());
        }

        // GET: Jugadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var jugador = await _context.Jugador
                .Include(j => j.Club)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null) return NotFound();

            return View(jugador);
        }

        // GET: Jugadores/Create
        public IActionResult Create()
        {
            CargarClubes();
            return View();
        }

        // POST: Jugadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Posicion,Dorsal,ClubId")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CargarClubes(jugador.ClubId); // si hay errores, la lista sigue llena
            return View(jugador);
        }

        // GET: Jugadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador == null) return NotFound();

            CargarClubes(jugador.ClubId);
            return View(jugador);
        }

        // POST: Jugadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Posicion,Dorsal,ClubId")] Jugador jugador)
        {
            if (id != jugador.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Jugador.Any(e => e.Id == jugador.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            CargarClubes(jugador.ClubId); // si hay errores, la lista sigue llena
            return View(jugador);
        }

        // GET: Jugadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var jugador = await _context.Jugador
                .Include(j => j.Club)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null) return NotFound();

            return View(jugador);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugador.Remove(jugador);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
