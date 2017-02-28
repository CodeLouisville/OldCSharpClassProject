using HogWarsh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HogWarsh.Repositories
{
    public class StudentRepository
    {
        public void Create(Student student)
        {
            using (var context = new Context())
            {
                context.Students.Add(student);

                context.SaveChanges();
            }
        }

        public void Update(Student student)
        {
            using (var context = new Context())
            {
                var studentToUpdate = context.Students.Find(student.Id);
                studentToUpdate.Name = student.Name;
                studentToUpdate.Species = student.Species;
                studentToUpdate.House = student.House;
                context.Entry(studentToUpdate.House).State = System.Data.Entity.EntityState.Unchanged;
                
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new Context())
            {
                var studentToRemove = context.Students.Find(id);
                context.Students.Remove(studentToRemove);

                context.SaveChanges();
            }
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            using (var context = new Context())
            {
                students = context.Students.Include("House").ToList();
            }

            return students;
        }

        public List<Student> GetStudentsWithoutHouses()
        {
            List<Student> students = new List<Student>();
            using (var context = new Context())
            {
                students = context.Students.Where(x => x.House == null).ToList();
            }

            return students;
        }

        public Student GetById(int id)
        {
            Student student = null;
            using (var context = new Context())
            {
                student = context.Students.Find(id);
            }

            return student;
        }
    }
}