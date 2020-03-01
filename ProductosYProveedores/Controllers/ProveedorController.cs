using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductosYProveedores.Models;

namespace ProductosYProveedores.Controllers
{
    public class ProveedorController : Controller
    {
        private GestorProveedores gestor;

        public ProveedorController()
        {
            gestor = GestorProveedores.GetInstance;
        }

        public ActionResult Mostrar()
        {

            return View(gestor.ObtenerProveedores());
        }

        // GET: Productos/Create
        public ActionResult Agregar()
        {
            return View();
        }
        // POST: Productos/Create
        [HttpPost]
        public ActionResult Agregar(Proveedores proveedor)
        {
            try
            {
                gestor.AgregarProveedor(proveedor);
                IList<Proveedores> proveedores = gestor.ObtenerProveedores();
                return RedirectToAction(nameof(Mostrar), proveedores);
            }
            catch
            {
                return View();
            }
        }
        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            Proveedores proveedor = gestor.ObtenerProveedor(id);
            return View(proveedor);
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string vacio = null)
        {
            try
            {

                gestor.EliminarProveedor(id);
                return RedirectToAction(nameof(Mostrar));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            Proveedores proveedor = gestor.ObtenerProveedor(id);
            return View(proveedor);
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Edit(int id, Proveedores proveedor)
        {
            try
            {

                gestor.EditarProveedor(id, proveedor);
                return RedirectToAction(nameof(Mostrar), gestor.ObtenerProveedores());
            }
            catch
            {
                return View(proveedor);
            }
        }
    }
}