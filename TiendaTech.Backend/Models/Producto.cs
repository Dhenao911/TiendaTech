using System;
using System.Collections.Generic;

namespace TiendaTech.Backend.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int? CtegoryId { get; set; }

    public virtual Categoria? Ctegory { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
