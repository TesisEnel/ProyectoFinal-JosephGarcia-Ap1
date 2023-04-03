using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PagosTennis{

    [Key]
    public int PagoId { get ; set; }
    [Required(ErrorMessage = "La ClienteId es requerida")]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "La TenniId es requerida")]
    public int TenniId { get; set; }
    [Required(ErrorMessage = "La Fecha de pago es requerida")]
    public DateOnly FechaPago { get; set; }
    [Required(ErrorMessage = "La concepto es requerida")]
    public string? Concepto { get; set; }

    [ForeignKey("PagoId")]
    public virtual List<DetallePagosTennis> DetallePagosTennis {get; set;} = new List<DetallePagosTennis>();



}