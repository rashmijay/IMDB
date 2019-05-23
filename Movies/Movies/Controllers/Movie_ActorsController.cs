using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class Movie_ActorsController : Controller
    {
        private MovieEntities db = new MovieEntities();

        // GET: Movie_Actors
        public ActionResult Index()
        {
            var movie_Actors = db.Movie_Actors.Include(m => m.Actor).Include(m => m.Movy);
            return View(movie_Actors.ToList());
        }

        // GET: Movie_Actors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_Actors movie_Actors = db.Movie_Actors.Find(id);
            if (movie_Actors == null)
            {
                return HttpNotFound();
            }
            return View(movie_Actors);
        }

        // GET: Movie_Actors/Create
        public ActionResult Create()
        {
            ViewBag.Actor_Id = new SelectList(db.Actors, "Id", "Name");
            ViewBag.Movie_Id = new SelectList(db.Movies, "Id", "Name");
            return View();
        }

        // POST: Movie_Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Actor_Id,Movie_Id")] Movie_Actors movie_Actors)
        {
            if (ModelState.IsValid)
            {
                db.Movie_Actors.Add(movie_Actors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Actor_Id = new SelectList(db.Actors, "Id", "Name", movie_Actors.Actor_Id);
            ViewBag.Movie_Id = new SelectList(db.Movies, "Id", "Name", movie_Actors.Movie_Id);
            return View(movie_Actors);
        }

        // GET: Movie_Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_Actors movie_Actors = db.Movie_Actors.Find(id);
            if (movie_Actors == null)
            {
                return HttpNotFound();
            }
            ViewBag.Actor_Id = new SelectList(db.Actors, "Id", "Name", movie_Actors.Actor_Id);
            ViewBag.Movie_Id = new SelectList(db.Movies, "Id", "Name", movie_Actors.Movie_Id);
            return View(movie_Actors);
        }

        // POST: Movie_Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Actor_Id,Movie_Id")] Movie_Actors movie_Actors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie_Actors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Actor_Id = new SelectList(db.Actors, "Id", "Name", movie_Actors.Actor_Id);
            ViewBag.Movie_Id = new SelectList(db.Movies, "Id", "Name", movie_Actors.Movie_Id);
            return View(movie_Actors);
        }

        // GET: Movie_Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_Actors movie_Actors = db.Movie_Actors.Find(id);
            if (movie_Actors == null)
            {
                return HttpNotFound();
            }
            return View(movie_Actors);
        }

        // POST: Movie_Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie_Actors movie_Actors = db.Movie_Actors.Find(id);
            db.Movie_Actors.Remove(movie_Actors);
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
