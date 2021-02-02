using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using J_Stack.Logic;
using J_Stack.Models;

namespace J_Stack.Controllers
{
    public class CoursesController : Controller
    {
        private CourseLogic db = new CourseLogic();
        private DbDatabase cb = new DbDatabase();

        //Get Degree under this course
        public ActionResult getDegreeForCourse(int id)
        {
            return View(cb.Degrees.Where(x=>x.D_Id == id).ToList());
        }
        // GET: Courses
        public ActionResult Index()
        {
            var courses = cb.Courses.Include(c => c.degrees);
            return View(courses.ToList());
        }


        // GET: Degrees/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
                return RedirectToAction("Bad_Request", "Error");
            if (db.FindById(id) != null)
                return View(db.FindById(id));
            else
                return RedirectToAction("Not_Found", "Error");
        }

        // GET: Degrees/Create
        public ActionResult Create()
        {
            ViewBag.D_Id = new SelectList(cb.Degrees, "D_Id", "DegreeName");
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course model)
        {
            if (ModelState.IsValid)
            {
                DegreeLogic mns = new DegreeLogic();
                int degree = mns.GetDegrees().Where(X => X.D_Id == model.D_Id).Select(Y => Y.D_Id).SingleOrDefault();
                string courseName = db.GetCourses().Where(X => X.CourseName == model.CourseName && X.D_Id ==degree).Select(Y => Y.CourseName).FirstOrDefault();
                if(courseName == model.CourseName)
                {
                    ModelState.AddModelError("CustomError", "Course with the same name, under the same selected degree already exist");
                }
                else
                {
                    db.Add(model);
                    return RedirectToAction("Index");
                }
               
            }

            return View(model);
        }

        // GET: Degrees/Edit/5

        public ActionResult Edit(int id)
        {
            if (id == null)
                return RedirectToAction("Bad_Request", "Error");
            if (db.FindById(id) != null)
                return View(db.FindById(id));
            else
                return RedirectToAction("Not_Found", "Error");
           
            ViewBag.D_Id = new SelectList(cb.Degrees, "D_Id", "DegreeName");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course model)
        {
            if (ModelState.IsValid)
            {

                db.Edit(model);
                return RedirectToAction("Index");
            }
            ViewBag.D_Id = new SelectList(cb.Degrees, "D_Id", "DegreeName");
            return View(model);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (id == null)
                return RedirectToAction("Bad_Request", "Error");
            if (db.FindById(id) != null)
                return View(db.FindById(id));
            else
                return RedirectToAction("Not_Found", "Error");
        }
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
