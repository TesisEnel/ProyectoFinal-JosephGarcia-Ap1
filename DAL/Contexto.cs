public class Contexto : DbContext
{
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Tenis> Tenis { get; set; }
    public DbSet<Entrada> Entrada { get; set; }
    public DbSet<Venta> Venta { get; set; }

    public Contexto(DbContextOptions <Contexto> options) : base(options){}

}