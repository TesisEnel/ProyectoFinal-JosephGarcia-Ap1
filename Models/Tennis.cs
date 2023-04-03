using System.ComponentModel.DataAnnotations;

public class Tennis{
    [Key]
    public int TenniId {get;set;}
    public string? Marca {get;set;}
    public double Costo { get; set; }
    public double Precio { get; set; }
    public int Existencia { get; set; }

    public Tennis(){
        this.Marca = string.Empty;
        this.Costo = 0;
        this.Precio =0;
        this.Existencia = 0;
    }
}