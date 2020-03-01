using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosYProveedores.Models
{
    public class Productos
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha_Venc { get; set; }
        public int Id_Proveedor { get; set; }


    }
}
