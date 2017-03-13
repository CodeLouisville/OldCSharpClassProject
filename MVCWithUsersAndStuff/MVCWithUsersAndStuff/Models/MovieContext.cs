using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWithUsersAndStuff.Models
{
    public class MovieContext :DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public Guid UserId { get; set; }
    }
}