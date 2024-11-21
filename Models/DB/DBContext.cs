using System.Collections.Generic;

namespace veebRogovski.Models.DB
{
    public class DBContext : DbContext
    {
        //add-migration 
        //update-database
        public DbSet<Toode> Tooded { get; set; }
        public DbSet<Kasutaja> Kasutajad { get; set; }
        public DbSet<Tellimus> Tellimused { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            if (!Kasutajad?.Where(x => x.IsAdmin).Any() ?? false)
            {
                Kasutajad.Add(new(0, "admin", "admin", "admin", "admin", true));
                SaveChanges();
            }
        }
    }
}
