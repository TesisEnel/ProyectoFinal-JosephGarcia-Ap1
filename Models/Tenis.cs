using System.ComponentModel.DataAnnotations;

public class Tenis{
    [Key]
    public int TeniId {get;set;}
    [Required(ErrorMessage ="La descripción es un campo necesario")]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage ="La marca es un campo necesario")]
    public string? Marca { get; set;} 
    [Range(1, double.MaxValue, ErrorMessage = "El valor ingresado en el costo debe ser mayor que cero.")]
    public double Costo { get; set; }
    [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
    public double Precio { get; set; }
    [Required(ErrorMessage ="El color es un campo necesario necesario")]
    public string? Color { get; set;}
    [Range(1, double.MaxValue, ErrorMessage = "El valor ingresado en el itbis debe ser mayor a cero.")]
    public double Itbis { get; set; }
    [Required(ErrorMessage ="El size es un campo necesario")]
    public string? Size { get; set;}
    [Required(ErrorMessage ="La fecha es un campo necesario")]
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public int Existencia { get; set; } = 0;


}