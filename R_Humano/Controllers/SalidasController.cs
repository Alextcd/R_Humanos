using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using R_Humanos.Models;

namespace R_Humanos.Controllers
{
    public class SalidasController : Controller
    {
        private R_HumanosEntities db = new R_HumanosEntities();

        // GET: Salidas
        public ActionResult Index()
        {
            var salidas = db.Salidas.Include(s => s.Empleado);
            return View(salidas.ToList());
        }

        // GET: Salidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = db.Salidas.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // GET: Salidas/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "Id", "Nombre");
            return View();
        }

        // POST: Salidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpleado,Tipo_de_salida,Motivo,Fecha_salida")] Salida salida)
        {
            if (ModelState.IsValid)
            {
                var empleado = (from e in db.Empleados where e.Id == salida.IdEmpleado select e);
                salida.Empleado = empleado.ToList<Empleado>().ElementAt(0);
                salida.Empleado.Estatus = "Inactivo";
                db.Salidas.Add(salida);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.IdEmpleado = new SelectList(db.Empleados, "Id", "Nombre", salida.IdEmpleado);
            return View(salida);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
