using System;
using System.Collections.Generic;

namespace TiendaTech.Backend.Models;

public partial class Categoria
{
    public int CategoryId { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public string Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
