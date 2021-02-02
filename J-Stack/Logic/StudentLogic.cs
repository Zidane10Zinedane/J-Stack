using J_Stack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace J_Stack.Logic
{
    public class StudentLogic
    {
        DbDatabase db = new DbDatabase();
        public void Add(Student P)
        {
            db.Students.Add(P);
            db.SaveChanges();
        }

        public void Edit(Student P)
        {
            db.Entry(P).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Student FindById(int Id)
        {
            var result = (from x in db.Students where x.S_Id == Id select x).SingleOrDefault();
            return result;
        }

        public IEnumerable<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        public void Remove(int Id)
        {
            Student P = db.Students.Find(Id);
            db.Students.Remove(P);
            db.SaveChanges();
        }
        public IEnumerable<Degree> GetDegreeForStudent(int id)
        {
            return db.Degrees.Where(x => x.D_Id == id).ToList();
        }
        public IEnumerable<Course> GetCoursesStudent(int id)
        {
            return db.Courses.Where(x => x.D_Id == id).ToList();
        }
    }
}