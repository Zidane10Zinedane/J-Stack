using J_Stack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace J_Stack.Logic
{
    public class CourseLogic
    {
        DbDatabase db = new DbDatabase();
        public void Add(Course P)
        {
            db.Courses.Add(P);
            db.SaveChanges();
        }

        public void Edit(Course P)
        {
            db.Entry(P).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Course FindById(int Id)
        {
            var result = (from x in db.Courses where x.C_Id == Id select x).SingleOrDefault();
            return result;
        }

        public IEnumerable<Course> GetCourses()
        {
            return db.Courses.ToList();
        }

        public void Remove(int Id)
        {
            Course P = db.Courses.Find(Id);
            db.Courses.Remove(P);
            db.SaveChanges();
        }

        public IEnumerable<Degree> GetDegreeForCourse(int id)
        {
            return db.Degrees.Where(x => x.D_Id == id).ToList();
        }
    }
}