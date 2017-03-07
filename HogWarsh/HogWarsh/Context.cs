using HogWarsh.Models;
using System.Data.Entity;

namespace HogWarsh
{
    public class Context : DbContext
    {
        public Context() :base("HogWarshConnectionString")
        {
            Database.SetInitializer(new MyInitializer());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<House> Houses { get; set; }
    }
    public class MyInitializer : 
        DropCreateDatabaseIfModelChanges<Context>
        //DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            context.Houses.Add(new House()
            {
                Name = "Furrby"
            });
            context.Houses.Add(new House()
            {
                Name = "NomNom"
            });
            context.Houses.Add(new House()
            {
                Name = "Wagabond"
            });
            base.Seed(context);
        }
    }
}