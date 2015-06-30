using Blogger.Application;
using Blogger.Domain;
using Blogger.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blogger.UI.Web.Controllers
{
    public class PacienteController : Controller
    {
        private IPacienteService service = new PacienteService(new PacienteRepository());

        // GET: /Paciente/
        public ActionResult Index()
        {
            return View(service.RetrieveAll());
        }

        // GET: /Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int i = (int)id;

            Paciente paciente = service.Retrieve(i);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: /Paciente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Paciente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenome,DataConsulta")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                service.Create(paciente);
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        // GET: /Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Paciente paciente = service.Retrieve(i);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: /Paciente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sobrenome,DataConsulta")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                service.Update(paciente);
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: /Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Paciente paciente = service.Retrieve(i);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: /Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
