using System.ComponentModel.DataAnnotations;

public class Cliente{

    [Key]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "El campo nombre es necesario")]
    public string? NombreCompleto { get; set; }
    [Required(ErrorMessage = "El campo cédula es necesario")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "La cédula debe tener tener 11 dígitos.")]
    public string? Cedula { get; set; }
    [Required(ErrorMessage = "El campo ciudad es necesario")]
    public string? Ciudad { get; set; }
    [Required(ErrorMessage = "El campo dirección es necesaria")]
    public string? Direccion { get; set; }
    [Required(ErrorMessage = "El campo telefono es necesario")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener tener 10 dígitos.")]
    public string? Telefono { get; set; }
    [Required(ErrorMessage = "El campo email es necesario")]
    public string? Email { get; set; }
    
    

}