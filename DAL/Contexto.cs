public class Contexto : DbContext
{
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Tenis> Tenis { get; set; }
    public DbSet<Marca> Marca { get; set; }
    public DbSet<Entrada> Entrada { get; set; }

    public Contexto(DbContextOptions <Contexto> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Marca>().HasData(
            new Marca{
                MarcaId = 1,
                NombreMarca = "Nike"
            }
        );
        modelBuilder.Entity<Marca>().HasData(
            new Marca{
                MarcaId = 2,
                NombreMarca = "Adidas"
            }
        );
        modelBuilder.Entity<Marca>().HasData(
            new Marca{
                MarcaId = 3,
                NombreMarca = "UnderArmour"
            }
        );
        modelBuilder.Entity<Marca>().HasData(
            new Marca{
                MarcaId = 4,
                NombreMarca = "Jordan"
            }
        );
    }

}