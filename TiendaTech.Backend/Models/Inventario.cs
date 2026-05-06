using System;
using System.Collections.Generic;

namespace TiendaTech.Backend.Models;

public partial class Inventario
{
    public int InventarioId { get; set; }

    public int? ProductoId { get; set; }

    public int StockActual { get; set; }

    public string UbicacionBodega { get; set; } = null!;

    public virtual Producto? Producto { get; set; }
}
