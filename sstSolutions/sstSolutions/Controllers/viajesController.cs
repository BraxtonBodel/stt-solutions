using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sstSolutions.Models;

namespace sstSolutions.Controllers
{
    public class viajesController : Controller
    {
        private readonly sstSolutionsContext _context;

        public viajesController(sstSolutionsContext context)
        {
            _context = context;
        }

        // GET: viajes
        public async Task<IActionResult> Index()
        {
            return View(await _context.viaje.ToListAsync());
        }

        // GET: viajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.viaje
                .FirstOrDefaultAsync(m => m.viajeId == id);
            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        // GET: viajes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: viajes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("viajeId,horaPartida,horaLlegada,tiempoViaje")] viaje viaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viaje);
        }

        // GET: viajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.viaje.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }
            return View(viaje);
        }

        // POST: viajes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("viajeId,horaPartida,horaLlegada,tiempoViaje")] viaje viaje)
        {
            if (id != viaje.viajeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!viajeExists(viaje.viajeId))
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
            return View(viaje);
        }

        // GET: viajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.viaje
                .FirstOrDefaultAsync(m => m.viajeId == id);
            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        // POST: viajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viaje = await _context.viaje.FindAsync(id);
            _context.viaje.Remove(viaje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool viajeExists(int id)
        {
            return _context.viaje.Any(e => e.viajeId == id);
        }
    }
}
