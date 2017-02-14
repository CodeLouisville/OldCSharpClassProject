using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HogWarsh.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // public Species Species { get; set; }
        public string Species { get; set; }
        public virtual House House { get; set; }
    }

    public class House
    {

    }

    public enum Species
    {
        Feline, 
        Canine,
        Fishy
    }

}
