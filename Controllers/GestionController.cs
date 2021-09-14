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
    public class GestionController : Controller
    {
        private Projet_DOT_NETEntities db = new Projet_DOT_NETEntities();

        // GET: Gestion
        [Authorize]
        public ActionResult Stat()
        { return View(); }
        public ActionResult Index(string etat, string IdNR)
        {
            var nrs = db.NRS.ToList();
            if (!String.IsNullOrEmpty(etat))
            {
                nrs = db.NRS.Where(x => x.Etat.Contains(etat)).ToList();
            }
            if (!String.IsNullOrEmpty(IdNR))
            {
                nrs = db.NRS.Where(x => x.NR_Id.Contains(IdNR)).ToList();
            }


            return View(nrs);
        }
        //Traitement
        public ActionResult Visualiser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NR nr = db.NRS.Find(id);
            if (nr == null)
            {
                return HttpNotFound();
            }
            return View(nr);
        }

        // GET: Gestion/Details/5
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

        // GET: Gestion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gestion/Create
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

        // GET: Gestion/Edit/5
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

        // POST: Gestion/Edit/5
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

        // GET: Gestion/Delete/5
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

        // POST: Gestion/Delete/5
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
    }
}
