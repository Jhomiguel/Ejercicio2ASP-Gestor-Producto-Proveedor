using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductosYProveedores.Models;

namespace ProductosYProveedores.Controllers
{   
   
    public class ProductoController : Controller
    {
        private GestorProductos gestor;
        public ProductoController()
        {
            gestor = GestorProductos.GetInstance;
        }
        
        // GET: Productos
        public ActionResult Mostrar()
        {
          
            return View(gestor.ObtenerProductos());
        }

        // GET: Productos/Create
        public ActionResult Agregar()
        {
            return View();
        }
        // POST: Productos/Create
        [HttpPost]
        public ActionResult Agregar(Productos producto)
        {
            try
            {
                gestor.AgregarProducto(producto);
                IList<Productos> productos = gestor.ObtenerProductos();
                return RedirectToAction(nameof(Mostrar),productos);
            }
            catch
            {
                return View();
            }
        }
        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            Productos producto = gestor.ObtenerProducto(id);
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string vacio=null)
        {
            try
            {  

                gestor.EliminarProducto(id);
                return RedirectToAction(nameof(Mostrar));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            Productos producto = gestor.ObtenerProducto(id);
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Edit(int id, Productos producto)
        {
            try
            {
               
                gestor.EditarProducto(id,producto);
                return RedirectToAction(nameof(Mostrar), gestor.ObtenerProductos());
            }
            catch
            {
                return View(producto);
            }
        }
    }
}