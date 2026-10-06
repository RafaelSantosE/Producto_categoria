using System.ComponentModel.DataAnnotations;

namespace Producto_categoria.Models;

public partial class Supplier
{
    [Key]
    public int SupplierId { get; set; }

    [StringLength(100)]
    public string CompanyName { get; set; } = null!;
}