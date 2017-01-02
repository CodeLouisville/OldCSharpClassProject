using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HogWarsh1.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string House { get; set; }
    }

    public class House
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Species
    {
        public string Name { get; set; }
    }

    public class InMemoryDatabase
    {
        public static List<House> Houses { get; private set; }
        public static List<Student> Students { get; private set; }
        public static List<Species> Species { get; private set; }

        static InMemoryDatabase()
        {
            Houses = new List<House>() {
                new Models.House() {
                    Name="Wagabond",
                    Description="Free spirited"
                },
                new House()
                {
                    Name="Whiskerful",
                    Description = "Sensitive"
                },
                                new House()
                {
                    Name="Pawntiferous",
                    Description = "Likes to move a lot."
                },
                new House()
                {
                    Name="Nommy Nom",
                    Description = "Yes, I'd like a treat with that."
                }
            };
            Species = new List<Species>
            {
                new Models.Species { Name="Feline" },
                new Models.Species {Name = "Canine" }
            };
            Students = new List<Student> {
                new Student {  Name="Garfield", Species="Feline", House="Nommy Nom"},
                new Student { Name="Odie", Species = "Canine" },
                new Student { Name="Marmaduke", Species="Canine" },
                new Student { Name="Lassie", Species="Canine" },
                new Student { Name="Mr Mistopholes", Species="Feline" }
            };
        }

        internal static List<House> GetAllHouses()
        {
            // this would become something that talks to the real database
            return Houses;
        }

        internal static List<Species> GetAllSpecies()
        {
            return Species;
        }

        internal static void SaveStudent(Student student)
        {
            var existingStudent = Students.FirstOrDefault(s => s.Name == student.Name);
            if (existingStudent != null)
            {
                // student already exists, this was an update.
                existingStudent.House = student.House;
                existingStudent.Species = student.Species;
            }
            else
            {
                // this was an insert. 
                Students.Add(student);
            }
        }


        internal static List<Student> GetStudentsForHouse(string name)
        {
            return Students.Where(s => s.House == name).ToList();
        }


        internal static List<Student> GetStudentsWithoutAHouse()
        {
            return Students.Where(s => String.IsNullOrEmpty(s.House)).ToList();
        }
    }

}