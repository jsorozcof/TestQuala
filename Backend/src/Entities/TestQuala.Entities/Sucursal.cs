using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuala.Entities
{
    public class Sucursal
    {
        public int Id { get; set; }

        public int Codigo { get; set; }

        public string Descripcion { get; set; } = null!;

        public string? Direccion { get; set; }

        public string Identificacion { get; set; } = null!;

        public int IdModena { get; set; }

        public DateTime? FechaCreacion { get; set; }

    }

    public class DtoSucursal
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public string Moneda { get; set; } = null!;
        public int IdMoneda { get; set; }

    }
}
