using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace inventariosmvc.Models;

public partial class Producto
{
    [Key]
    public Guid Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Existencia { get; set; }

    public int IdMarca { get; set; }

    public DateTime FechaRegistro { get; set; }
}
