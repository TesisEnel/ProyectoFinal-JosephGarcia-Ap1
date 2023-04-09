using System.ComponentModel.DataAnnotations;

public class Entrada
{
    [Key]
    public int EntradaId { get; set; }
    [Required(ErrorMessage = "El nombre de la marca es necesario.")]
    public string? Marca { get; set; }
    [Required(ErrorMessage = "La fecha es necesaria.")]
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [Range(1, int.MaxValue, ErrorMessage = "El valor ingresado en la cantidad debe ser mayor que cero.")]
    public int Cantidad { get; set; }
    [Required(ErrorMessage = "El color es un campo necesario necesario")]
    public string? Color { get; set; }
    [Required(ErrorMessage = "El size es un campo necesario")]
    public string? Size { get; set; }
}