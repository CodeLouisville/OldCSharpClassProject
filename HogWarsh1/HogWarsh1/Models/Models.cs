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
            Students = new List<Student> { };
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
            Students.Add(student);
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