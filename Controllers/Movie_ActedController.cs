using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IndianMovies.Models;

using Vudayamarri_Project.DAL;

namespace Vudayamarri_Project.Controllers
{
    public class Movie_ActedController : Controller
    {
        private IndianMoviesContext db = new IndianMoviesContext();

        // GET: Movie_Acted
        public ActionResult Index()
        {
            var movies_Acted = db.Movies_Acted.Include(m => m.Actor).Include(m => m.Movie);
            return View(movies_Acted.ToList());
        }

        // GET: Movie_Acted/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_Acted movie_Acted = db.Movies_Acted.Find(id);
            if (movie_Acted == null)
            {
                return HttpNotFound();
            }
            return View(movie_Acted);
        }

        // GET: Movie_Acted/Create
        public ActionResult Create()
        {
            ViewBag.ActorID = new SelectList(db.Actors, "ID", "LastName");
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName");
            return View();
        }

        // POST: Movie_Acted/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Movie_ActedID,MovieID,ActorID")] Movie_Acted movie_Acted)
        {
            if (ModelState.IsValid)
            {
                db.Movies_Acted.Add(movie_Acted);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorID = new SelectList(db.Actors, "ID", "LastName", movie_Acted.ActorID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName", movie_Acted.MovieID);
            return View(movie_Acted);
        }

        // GET: Movie_Acted/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_Acted movie_Acted = db.Movies_Acted.Find(id);
            if (movie_Acted == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorID = new SelectList(db.Actors, "ID", "LastName", movie_Acted.ActorID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName", movie_Acted.MovieID);
            return View(movie_Acted);
        }

        // POST: Movie_Acted/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Movie_ActedID,MovieID,ActorID")] Movie_Acted movie_Acted)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie_Acted).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorID = new SelectList(db.Actors, "ID", "LastName", movie_Acted.ActorID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName", movie_Acted.MovieID);
            return View(movie_Acted);
        }

        // GET: Movie_Acted/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_Acted movie_Acted = db.Movies_Acted.Find(id);
            if (movie_Acted == null)
            {
                return HttpNotFound();
            }
            return View(movie_Acted);
        }

        // POST: Movie_Acted/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie_Acted movie_Acted = db.Movies_Acted.Find(id);
            db.Movies_Acted.Remove(movie_Acted);
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
