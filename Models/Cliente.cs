using System.ComponentModel.DataAnnotations;

public class Cliente{

    [Key]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "El campo nombre esta vacio")]
    public string? NombreCompleto { get; set; }
    [Required(ErrorMessage = "El campo cedula esta vacio")]
    public string? Cedula { get; set; }
    [Required(ErrorMessage = "El campo ciudad esta vacio")]
    public string? Ciudad { get; set; }
    [Required(ErrorMessage = "El campo direccion esta vacio")]
    public string? Direccion { get; set; }
    [Required(ErrorMessage = "El campo telefono esta vacio")]
    public string? Telefono { get; set; }

}