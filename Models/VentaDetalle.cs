using System.ComponentModel.DataAnnotations;

public class VentaDetalle{
    [Key]
    public int VentaDetalleId { get; set; }
    public int VentaId { get; set; }
    public int MarcaId { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public int Cantidad { get; set; }
}