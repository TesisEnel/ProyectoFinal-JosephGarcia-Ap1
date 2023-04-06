using System.ComponentModel.DataAnnotations;

public class Entrada{
    [Key]
    public int EntradaId { get; set; }
    [Required(ErrorMessage = "El id del teni es necesario.")]
    public int TeniId { get; set; }
    [Required(ErrorMessage = "La fecha es necesaria.")]
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [Range(1, int.MaxValue, ErrorMessage = "El valor ingresado en la cantidad debe ser mayor que cero.")]
    public int Cantidad { get; set; }
}