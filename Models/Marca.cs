using System.ComponentModel.DataAnnotations;
public class Marca{
    [Key]
    public int MarcaId { get; set; }
    public string? NombreMarca { get; set; }
}