using HogWarsh.Models;
using System.Data.Entity;

namespace HogWarsh
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer(new MyCustomInitializer());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<House> Houses { get; set; }
    }

    public class MyCustomInitializer: 
        //DropCreateDatabaseAlways<Context>
        DropCreateDatabaseIfModelChanges<Context>
    {
        public override void InitializeDatabase(Context context)
        {

            context.Houses.Add(new House() { Name = "Wagabond" });
            context.Houses.Add(new House() { Name = "Furrby" });
            context.Houses.Add(new House() { Name = "NommyNom" });
            context.Houses.Add(new House() { Name = "Tailented" });
            context.Houses.Add(new House() { Name = "Equitable" });
            // context.SaveChanges()
            base.InitializeDatabase(context);
        }
    }
}