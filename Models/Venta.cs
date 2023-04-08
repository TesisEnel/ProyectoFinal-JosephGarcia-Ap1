using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Venta{
    [Key]
    public int VentaId { get; set; }
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public int ClienteId { get; set; }
    public string? Concepto { get; set; }
    
    [ForeignKey("VentaId")]
    public virtual List<VentaDetalle> VentaDetalle {get; set;} = new List<VentaDetalle>();
}