using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinanceManager.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FinanceManager.Controllers
{
    public class FinanzaController : Controller
    {
        private readonly FinanceDbContext _context;

        public FinanzaController(FinanceDbContext context)
        {
            _context = context;
        }

        // GET: Finanza
        public async Task<IActionResult> Index(string sortOrder)
        {
            // Definir el orden por defecto como ascendente por fecha
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

            var finanzas = from f in _context.Finanzas.Include(f => f.Categoria)
                           select f;

            // Ordenar según el parámetro de orden recibido
            switch (sortOrder)
            {
                case "date_desc":
                    finanzas = finanzas.OrderByDescending(f => f.Fecha);
                    break;
                default:
                    finanzas = finanzas.OrderBy(f => f.Fecha);
                    break;
            }

            var finanzasList = await finanzas.ToListAsync();

            // Calcular el total de capital actual
            decimal totalCapital = finanzasList
                .Where(f => f.Tipo == "Ingreso").Sum(f => f.Monto) -
                finanzasList.Where(f => f.Tipo == "Egreso").Sum(f => f.Monto);

            // Pasar el valor a la vista utilizando ViewBag
            ViewBag.TotalCapital = totalCapital;

            return View(finanzasList);
        }





        // GET: Finanza/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finanza = await _context.Finanzas
                .Include(f => f.Categoria)  // Incluye la entidad relacionada Categoria
                .FirstOrDefaultAsync(m => m.Id == id);

            if (finanza == null)
            {
                return NotFound();
            }

            return View(finanza);
        }


        // GET: Finanza/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre");
            return View();
        }

        // POST: Finanza/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Monto,CategoriaId,Descripcion,Fecha")] Finanza finanza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finanza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", finanza.CategoriaId);
            return View(finanza);
        }


        // GET: Finanza/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finanza = await _context.Finanzas.FindAsync(id);
            if (finanza == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", finanza.CategoriaId);
            return View(finanza);
        }

        // POST: Finanza/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Monto,CategoriaId,Descripcion,Fecha")] Finanza finanza)
        {
            if (id != finanza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finanza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanzaExists(finanza.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", finanza.CategoriaId);
            return View(finanza);
        }

        // GET: Finanza/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finanza = await _context.Finanzas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finanza == null)
            {
                return NotFound();
            }

            return View(finanza);
        }

        // POST: Finanza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finanza = await _context.Finanzas.FindAsync(id);
            if (finanza != null)
            {
                _context.Finanzas.Remove(finanza);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinanzaExists(int id)
        {
            return _context.Finanzas.Any(e => e.Id == id);
        }
    }
}
