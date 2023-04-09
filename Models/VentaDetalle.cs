using System.ComponentModel.DataAnnotations;

public class VentaDetalle{
    [Key]
    public int VentaDetalleId { get; set; }
    public int VentaId { get; set; }
    [Required(ErrorMessage ="Seleccionar la marca es necesario.")]
    public string? Marca { get; set; }
    [Required(ErrorMessage ="Seleccionar el color es necesario.")]
    public string? Color { get; set; }
    [Required(ErrorMessage ="Seleccionar el size es necesario.")]
    public string? Size { get; set; }
    [Range(1, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
    public int Cantidad { get; set; }
    public double Precio { get; set; }
    public int TeniId { get; set; }
}