using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosYProveedores.Models
{
    public class GestorProductos
    {
        private static GestorProductos instance = new GestorProductos();

        private List<Productos> GProductos = new List<Productos>();
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
