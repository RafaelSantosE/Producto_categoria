using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Producto_categoria.Data;
using Producto_categoria.Models;

namespace Producto_categoria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SampleDbContext _context;

        public HomeController(ILogger<HomeController> logger, SampleDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var modelo = new HomeViewModel
            {
                Categorias = await _context.Categories
                    .OrderBy(c => c.Name)
                    .Select(c => new CategoriaResumen
                    {
                        Id = c.CategoryId,
                        Nombre = c.Name,
                        Total = _context.Products.Count(p => p.Category != null && p.Category.CategoryId == c.CategoryId)
                    })
                    .Take(8)
                    .ToListAsync(),

                UltimosProductos = await _context.Products
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.ProductId)
                    .Take(3)
                    .ToListAsync(),

                TotalCategorias = await _context.Categories.CountAsync(),
                TotalProductos = await _context.Products.CountAsync(),
                SinCategoria = await _context.Products.CountAsync(p => p.Category == null)
            };

            return View(modelo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}