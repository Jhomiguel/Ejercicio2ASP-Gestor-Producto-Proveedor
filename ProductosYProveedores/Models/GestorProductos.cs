using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosYProveedores.Models
{
    public class GestorProductos
    {
        private static GestorProductos instance = new GestorProductos();

        private List<Productos> GProductos = new List<Productos>() 
        {
            new Productos() {ID = 1, Nombre="Salami", Descripcion="Induveca", Fecha_Venc=DateTime.Parse("12,02,2000"), Id_Proveedor=1},
            new Productos() {ID = 2, Nombre="Salami", Descripcion="Induveca", Fecha_Venc=DateTime.Parse("12,02,2000"), Id_Proveedor=2},
            new Productos() {ID = 3, Nombre="Salami", Descripcion="Induveca", Fecha_Venc=DateTime.Parse("12,02,2000"), Id_Proveedor=3},
            new Productos() {ID = 4, Nombre="Salami", Descripcion="Induveca", Fecha_Venc=DateTime.Parse("12,02,2000"), Id_Proveedor=4}
        };
        public static GestorProductos GetInstance => instance;
        private GestorProductos() { }
        
        public void AgregarProducto(Productos producto)
        {
            GProductos.Add(producto);
        }

        public void EliminarProducto(int Id)
        {
            foreach (Productos producto in GProductos)
            {
                if(producto.ID == Id)
                {
                    GProductos.Remove(producto);
                    break;
                }
            }
        }
        public Productos ObtenerProducto(int Id)
        {
            foreach (Productos producto in GProductos)
            {
                if (producto.ID == Id)
                {
                    return producto;
                }
            }
                    return null;
        }
        public List<Productos> EditarProducto(int Id,Productos producto)
        {
             var id = GProductos.FindIndex(c => c.ID == Id);
             GProductos[id] = producto;
             return GProductos;
        }

        public List<Productos> ObtenerProductos()
        {
            return GProductos;
        }
    }
}
