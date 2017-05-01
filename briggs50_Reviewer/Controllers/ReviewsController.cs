using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using briggs50_Reviewer.Models;
using briggs50_Reviewer.CustomAttribute;

namespace briggs50_Reviewer.Controllers
{
    public class ReviewsController : Controller
    {
      
            private ApplicationDbContext db = new ApplicationDbContext();

            [AuthorizeOrRedirectAttribute(Roles = "Admin, Reviewer")]
            public ActionResult ListOfReviewsByMovie(int ID)
            {
                var movieReviews = db.Reviews
                .Where(a => a.ID == ID).ToList();

                var movie = db.Movies.Find(ID);
                ViewBag.MovieTitle = movie.Title;


                return View(movieReviews);
            }
            // GET: Reviews
            public ActionResult Index()
            {
                return View(db.Reviews.ToList());
            }

            // GET: Reviews/Details/5
            [AuthorizeOrRedirectAttribute(Roles = "Admin, Reviewer")]
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Review review = db.Reviews.Find(id);
                if (review == null)
                {
                    return HttpNotFound();
                }
                return View(review);
            }

            // GET: Reviews/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Reviews/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            [AuthorizeOrRedirectAttribute(Roles = "Admin, Reviewer")]

            public ActionResult Create([Bind(Include = "DateCreated,Content,Rating,ID")] Review review, int ID)
            {
                var movie = db.Movies.Find(ID);

                ViewBag.MovieID = movie.ID;

                if (ModelState.IsValid)
                {
                    if (User.IsInRole("Admin"))
                    {
                        db.Reviews.Add(review);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else if (User.IsInRole("Reviewer"))
                    {
                        db.Reviews.Add(review);
                        db.SaveChanges();
                        return RedirectToAction("ListMovies");
                    }

                }

                return View(review);
            }

            // GET: Reviews/Edit/5
            [AuthorizeOrRedirectAttribute(Roles = "Admin")]
            public ActionResult Edit(int? ID)
            {
                if (ID == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Review review = db.Reviews.Find(ID);
                if (review == null)
                {
                    return HttpNotFound();
                }
                return View(review);
            }

            // POST: Reviews/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            [AuthorizeOrRedirectAttribute(Roles = "Admin")]
            public ActionResult Edit([Bind(Include = "ID,Content,DateCreated,Rating")] Review review)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(review).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(review);
            }

            // GET: Reviews/Delete/5
            [AuthorizeOrRedirectAttribute(Roles = "Admin")]
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Review review = db.Reviews.Find(id);
                if (review == null)
                {
                    return HttpNotFound();
                }
                return View(review);
            }

            // POST: Reviews/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            [AuthorizeOrRedirectAttribute(Roles = "Admin")]
            public ActionResult DeleteConfirmed(int id)
            {
                Review review = db.Reviews.Find(id);
                db.Reviews.Remove(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            public ActionResult Search(string q)
            {
                var reviews = db.Reviews
                    .Where(a => a.Content.Contains(q))
                    .ToList();

                return View(reviews);
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

