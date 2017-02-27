using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HogWarsh.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        // public Species Species { get; set; }
        public string Species { get; set; }
        public virtual House House { get; set; }
    }

    public class House
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum Species
    {
        Feline, 
        Canine,
        Fishy
    }

}
