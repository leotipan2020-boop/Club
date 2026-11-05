
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClubesApp.Models;

public class JugadorController : Controller
{
    private readonly ClubesAppContext _context;

    public JugadorController(ClubesAppContext context)
    {
        _context = context;
    }

    // GET: JUGADORS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Jugador.ToListAsync());
    }

    // GET: JUGADORS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var jugador = await _context.Jugador
            .FirstOrDefaultAsync(m => m.Id == id);
        if (jugador == null)
        {
            return NotFound();
        }

        return View(jugador);
    }

    // GET: JUGADORS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: JUGADORS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Posicion,Dorsal")] Jugador jugador)
    {
        if (ModelState.IsValid)
        {
            _context.Add(jugador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(jugador);
    }

    // GET: JUGADORS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var jugador = await _context.Jugador.FindAsync(id);
        if (jugador == null)
        {
            return NotFound();
        }
        return View(jugador);
    }

    // POST: JUGADORS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Posicion,Dorsal")] Jugador jugador)
    {
        if (id != jugador.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(jugador);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JugadorExists(jugador.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(jugador);
    }

    // GET: JUGADORS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var jugador = await _context.Jugador
            .FirstOrDefaultAsync(m => m.Id == id);
        if (jugador == null)
        {
            return NotFound();
        }

        return View(jugador);
    }

    // POST: JUGADORS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var jugador = await _context.Jugador.FindAsync(id);
        if (jugador != null)
        {
            _context.Jugador.Remove(jugador);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool JugadorExists(int? id)
    {
        return _context.Jugador.Any(e => e.Id == id);
    }
}
