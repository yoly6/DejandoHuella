using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carrito_de_compras.Data;
using Carrito_de_compras.Models;

namespace Carrito_de_compras.Controllers
{
    public class ModoPagosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModoPagosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ModoPagoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModoPago.ToListAsync());
        }

        // GET: ModoPagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modoPago = await _context.ModoPago
                .FirstOrDefaultAsync(m => m.ModoPagoId == id);
            if (modoPago == null)
            {
                return NotFound();
            }

            return View(modoPago);
        }

        // GET: ModoPagoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModoPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModoPagoId,ModoPagoDescripcion")] ModoPago modoPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modoPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modoPago);
        }

        // GET: ModoPagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modoPago = await _context.ModoPago.FindAsync(id);
            if (modoPago == null)
            {
                return NotFound();
            }
            return View(modoPago);
        }

        // POST: ModoPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModoPagoId,ModoPagoDescripcion")] ModoPago modoPago)
        {
            if (id != modoPago.ModoPagoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modoPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModoPagoExists(modoPago.ModoPagoId))
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
            return View(modoPago);
        }

        // GET: ModoPagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modoPago = await _context.ModoPago
                .FirstOrDefaultAsync(m => m.ModoPagoId == id);
            if (modoPago == null)
            {
                return NotFound();
            }

            return View(modoPago);
        }

        // POST: ModoPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modoPago = await _context.ModoPago.FindAsync(id);
            _context.ModoPago.Remove(modoPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModoPagoExists(int id)
        {
            return _context.ModoPago.Any(e => e.ModoPagoId == id);
        }
    }
}
