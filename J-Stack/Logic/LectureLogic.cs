using J_Stack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace J_Stack.Logic
{
    public class LectureLogic
    {
        DbDatabase db = new DbDatabase();
        public void Add(Lecture P)
        {
            db.Lectures.Add(P);
            db.SaveChanges();
        }

        public void Edit(Lecture P)
        {
            db.Entry(P).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Lecture FindById(int Id)
        {
            var result = (from x in db.Lectures where x.L_Id == Id select x).SingleOrDefault();
            return result;
        }

        public IEnumerable<Lecture> GetLectures()
        {
            return db.Lectures.ToList();
        }

        public void Remove(int Id)
        {
            Lecture P = db.Lectures.Find(Id);
            db.Lectures.Remove(P);
            db.SaveChanges();
        }
       
    }
}