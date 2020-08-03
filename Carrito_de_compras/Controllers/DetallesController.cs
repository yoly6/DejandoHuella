using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Carrito_de_compras.Data;
using Carrito_de_compras.Models;

namespace Carrito_de_compras.Controllers
{
    public class DetallesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetallesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Detalles
        public async Task<IActionResult> Index()
        {
            var carrito_de_comprasContext = _context.Detalle.Include(d => d.Factura).Include(d => d.Producto);
            return View(await carrito_de_comprasContext.ToListAsync());
        }

        // GET: Detalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle = await _context.Detalle
                .Include(d => d.Factura)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetalleId == id);
            if (detalle == null)
            {
                return NotFound();
            }

            return View(detalle);
        }

        // GET: Detalles/Create
        public IActionResult Create()
        {
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId");
            ViewData["ProductoId"] = new SelectList(_context.Set<Producto>(), "ProductosId", "ProductosNombre");
            return View();
        }

        // POST: Detalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleId,FacturaId,ProductoId,DetalleCantidad,DetallePrecio")] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId", detalle.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Set<Producto>(), "ProductosId", "ProductosNombre", detalle.ProductoId);
            return View(detalle);
        }

        // GET: Detalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle = await _context.Detalle.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId", detalle.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Set<Producto>(), "ProductosId", "ProductosNombre", detalle.ProductoId);
            return View(detalle);
        }

        // POST: Detalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleId,FacturaId,ProductoId,DetalleCantidad,DetallePrecio")] Detalle detalle)
        {
            if (id != detalle.DetalleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleExists(detalle.DetalleId))
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
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId", detalle.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Set<Producto>(), "ProductosId", "ProductosNombre", detalle.ProductoId);
            return View(detalle);
        }

        // GET: Detalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle = await _context.Detalle
                .Include(d => d.Factura)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.DetalleId == id);
            if (detalle == null)
            {
                return NotFound();
            }

            return View(detalle);
        }

        // POST: Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalle = await _context.Detalle.FindAsync(id);
            _context.Detalle.Remove(detalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleExists(int id)
        {
            return _context.Detalle.Any(e => e.DetalleId == id);
        }
    }
}
