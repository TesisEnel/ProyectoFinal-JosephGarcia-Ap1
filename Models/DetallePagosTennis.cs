using System.ComponentModel.DataAnnotations;

public class DetallePagosTennis{
    [Key]
    public int DetallesPagosId { get; set; }
    [Required(ErrorMessage = "El campo PagoId es obligatorio")]
    public int PagoId { get; set; }
    [Required(ErrorMessage = "El campo ClienteId es obligatorio")]
    public int ClienteId { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "El valor ingresado en valor de pago no es valido.")]
    public double ValorPago { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "El valor ingresado en cantidad no es valido.")]
    public int Cantidad { get; set; }
}