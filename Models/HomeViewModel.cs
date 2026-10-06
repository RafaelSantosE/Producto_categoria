using System.Collections.Generic;

namespace Producto_categoria.Models
{
    public class CategoriaResumen
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public int Total { get; set; }
    }

    public class HomeViewModel
    {
        public List<CategoriaResumen> Categorias { get; set; } = new();
        public List<Product> UltimosProductos { get; set; } = new();

        public int TotalCategorias { get; set; }
        public int TotalProductos { get; set; }
        public int SinCategoria { get; set; }
    }
}