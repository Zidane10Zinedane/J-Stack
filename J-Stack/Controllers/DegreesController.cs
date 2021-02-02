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
    public class DegreesController : Controller
    {
        private DegreeLogic db = new DegreeLogic();
        private DbDatabase cb = new DbDatabase();
        public ActionResult getCourseForDegree(int id)
        {
            return View(cb.Courses.Where(x => x.D_Id == id).ToList());
        }
        // GET: Degrees
        public ActionResult Index()
        {
            return View(db.GetDegrees());
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
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Degree model)
        {
            if (ModelState.IsValid)
            {
                string Name = db.GetDegrees().Where(x => x.DegreeName == model.DegreeName).Select(y=>y.DegreeName).SingleOrDefault();
                if (Name == model.DegreeName)
                {
                    ModelState.AddModelError("CustomError", "Degree with the same name already exist");
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
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Degree model)
        {
            if (ModelState.IsValid)
            {
                db.Edit(model);
                return RedirectToAction("Index");
            }
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
