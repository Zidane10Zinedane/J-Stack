using J_Stack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace J_Stack.Logic
{
    public class DegreeLogic
    {
        DbDatabase db = new DbDatabase();
        public void Add(Degree P)
        {
            db.Degrees.Add(P);
            db.SaveChanges();
        }

        public void Edit(Degree P)
        {
            db.Entry(P).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Degree FindById(int Id)
        {
            var result = (from x in db.Degrees where x.D_Id == Id select x).SingleOrDefault();
            return result;
        }

        public IEnumerable<Degree> GetDegrees()
        {
            return db.Degrees.ToList();
        }

        public void Remove(int Id)
        {
            Degree P = db.Degrees.Find(Id);
            db.Degrees.Remove(P);
            db.SaveChanges();
        }
        public IEnumerable<Course> GetCoursesForDegree(int id)
        {
            return db.Courses.Where(x=>x.D_Id == id).ToList();
        }
    }
}