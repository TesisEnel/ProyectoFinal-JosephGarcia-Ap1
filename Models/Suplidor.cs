using System.ComponentModel.DataAnnotations;

public class Suplidor{

    [Key]
    public int SuplidorId { get; set; }

    [Required(ErrorMessage = "La marca es requerida")]
    public string? Marca { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Ingrese un precio valido")]
    public double PrecioVenta { get; set; }

    [Required(ErrorMessage = "El Email es requerida")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "El Telefono es requerida")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "El Direccion es requerida")]
    public string? Direccion { get; set; }

}