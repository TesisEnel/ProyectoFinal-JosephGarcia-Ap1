public class Contexto : DbContext
{
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<PagosTennis> PagosTennis { get; set; }
    public DbSet<Tennis> Tennis { get; set; }

    public Contexto(DbContextOptions <Contexto> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Tennis>().HasData(
            new Tennis{
                TenniId = 1,
                Marca = "Nike",
                Costo = 80,
                Precio = 100,
                Existencia = 50
            }
        );
        modelBuilder.Entity<Tennis>().HasData(
            new Tennis{
                TenniId = 2,
                Marca = "Adidas",
                Costo = 50,
                Precio = 80,
                Existencia = 50
            }
        );
        modelBuilder.Entity<Tennis>().HasData(
            new Tennis{
                TenniId = 3,
                Marca = "Jordan",
                Costo = 150,
                Precio = 200,
                Existencia = 50
            }
        );
    }

}