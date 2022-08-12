using dockcompyml.Models;
using Microsoft.EntityFrameworkCore;

namespace dockcompyml.Data{
public class AppDataDbcontext : DbContext
{
    public DbSet<Book> Books {get;set;}

    public AppDataDbcontext(DbContextOptions<AppDataDbcontext> options) : base(options)
    {

    }

 
protected override void OnModelCreating(ModelBuilder modelbuilder){
    base.OnModelCreating(modelbuilder);
    SnakeCasen(modelbuilder);
}

protected static void SnakeCasen(ModelBuilder m){
m.Entity<Book>(
    b=>{
    b.ToTable("book");}
    );
}

}
}