using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blogger.Application;
using Blogger.Domain;
using Blogger.Infra.Data;

namespace Blogger.UI.Web.Controllers
{
    public class MedicoController : Controller
    {
    private IMedicoService service = new MedicoService(new MedicoRepository());

        // GET: /Medico/
        public ActionResult Index()
        {
            return View(service.RetrieveAll());
        }

        // GET: /Medico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int i = (int)id;

            Medico medico = service.Retrieve(i);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: /Medico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Medico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Especialidade,CRM,Residente")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                service.Create(medico);
                return RedirectToAction("Index");
            }

            return View(medico);
        }

        // GET: /Medico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Medico medico = service.Retrieve(i);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: /Medico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Especialidade,CRM,Residente")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                service.Update(medico);
                return RedirectToAction("Index");
            }
            return View(medico);
        }

        // GET: /Medico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Medico medico = service.Retrieve(i);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: /Medico/Delete/5
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
