using HogWarsh.Models;
using System.Data.Entity;

namespace HogWarsh
{
    public class Context : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}