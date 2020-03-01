using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosYProveedores.Models
{
    public class GestorProveedores
    {
        private static GestorProveedores instance = new GestorProveedores();
        private List<Proveedores> GProveedores = new List<Proveedores>();
        public static GestorProveedores GetInstance => instance;
        private GestorProveedores(){ }

        public void AgregarProveedor(Proveedores proveedor)
        {
            GProveedores.Add(proveedor);
        }
        public void EliminarProveedor(int Id)
        {
            foreach (Proveedores producto in GProveedores)
            {
                if (producto.ID == Id)
                {
                    GProveedores.Remove(producto);
                    break;
                }
            }
        }

        public Proveedores ObtenerProveedor(int Id)
        {
            foreach (Proveedores proveedor in GProveedores)
            {
                if (proveedor.ID == Id)
                {
                    return proveedor;
                }
            }
            return null;
        }

        public List<Proveedores> ObtenerProveedores()
        {
            return GProveedores;
        }
    }
}
