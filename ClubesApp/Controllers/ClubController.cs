
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClubesApp.Models;

public class ClubController : Controller
{
    private readonly ClubesAppContext _context;

    public ClubController(ClubesAppContext context)
    {
        _context = context;
    }

    // GET: CLUBS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Club.ToListAsync());
    }

    // GET: CLUBS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var club = await _context.Club
            .FirstOrDefaultAsync(m => m.Id == id);
        if (club == null)
        {
            return NotFound();
        }

        return View(club);
    }

    // GET: CLUBS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CLUBS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Ciudad,Jugadores")] Club club)
    {
        if (ModelState.IsValid)
        {
            _context.Add(club);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(club);
    }

    // GET: CLUBS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var club = await _context.Club.FindAsync(id);
        if (club == null)
        {
            return NotFound();
        }
        return View(club);
    }

    // POST: CLUBS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Ciudad,Jugadores")] Club club)
    {
        if (id != club.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(club);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(club.Id))
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
        return View(club);
    }

    // GET: CLUBS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var club = await _context.Club
            .FirstOrDefaultAsync(m => m.Id == id);
        if (club == null)
        {
            return NotFound();
        }

        return View(club);
    }

    // POST: CLUBS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var club = await _context.Club.FindAsync(id);
        if (club != null)
        {
            _context.Club.Remove(club);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ClubExists(int? id)
    {
        return _context.Club.Any(e => e.Id == id);
    }
}
