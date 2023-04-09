using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Venta{
    [Key]
    public int VentaId { get; set; }
    [Required(ErrorMessage ="La fecha es un campo necesario.")]
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [Required(ErrorMessage ="Seleccionar el cliente es necesario.")]
    public int ClienteId { get; set; }
    [Required(ErrorMessage ="El concepto es un campo necesario.")]
    public string? Concepto { get; set; }
    public double Ganancias { get; set; }
    
    [ForeignKey("VentaId")]
    public virtual List<VentaDetalle> VentaDetalle {get; set;} = new List<VentaDetalle>();
}