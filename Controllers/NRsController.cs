using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using App.Models;

namespace App.Controllers
{

    public class NRsController : Controller
    {
        private Projet_DOT_NETEntities db = new Projet_DOT_NETEntities();

        // GET: NRs
        public ActionResult Index()
        {
            return View();
        }

        // GET: NRs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NR nR = db.NRS.Find(id);
            if (nR == null)
            {
                return HttpNotFound();
            }
            return View(nR);
        }

        // GET: NRs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NRs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OBJECTID,Reference_,Prenom,Societe,Qualite,Nature_ter,Zonage,indice_Equ,Voirie,Autres,NR_Id,Etat,SHAPE_STAr,SHAPE_STLe,SHAPE")] NR nR)
        {
            if (ModelState.IsValid)
            {
                db.NRS.Add(nR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nR);
        }

        // GET: NRs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NR nR = db.NRS.Find(id);
            if (nR == null)
            {
                return HttpNotFound();
            }
            return View(nR);
        }

        // POST: NRs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OBJECTID,Reference_,Prenom,Societe,Qualite,Nature_ter,Zonage,indice_Equ,Voirie,Autres,NR_Id,Etat,SHAPE_STAr,SHAPE_STLe,SHAPE")] NR nR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nR);
        }

        // GET: NRs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NR nR = db.NRS.Find(id);
            if (nR == null)
            {
                return HttpNotFound();
            }
            return View(nR);
        }

        // POST: NRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NR nR = db.NRS.Find(id);
            db.NRS.Remove(nR);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Carte()
        {
            return View();
        
        }
        public ActionResult Demande()
        {
            return View();
        }


        public ActionResult Consulte(string Ref)
        {
            {

                if (String.IsNullOrEmpty(Ref))
                {
                    return View("Consulte");
                    
                }
                var nr = db.NRS.Where(x => x.Reference_ == Ref).FirstOrDefault();

                return View(nr);
                
            }

            
        
        }
    }
}
