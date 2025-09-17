
using System.ComponentModel.DataAnnotations;
using FSH.Framework.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fgr.Sasp.Domain.Catalog;

public class CatalogoBase : AuditableEntity
{
    [Comment("Descripción del catálogo")]
    [Display(Name = "Descripción")]
    [Required(ErrorMessage = "El campo \"{0}\" es obligatorio")]
    [MaxLength(200, ErrorMessage = "La longitud máxima para {0} es de {1} caracteres")]
    public string? Descripcion { get; set; }

    [Comment("Descripción corta del catálogo")]
    [Display(Name = "Descripción Corta")]
    [Required(ErrorMessage = "El campo \"{0}\" es obligatorio")]
    [MaxLength(15, ErrorMessage = "La longitud máxima para {0} es de {1} caracteres")]
    public string? DesCorta { get; set; }

    [Comment("Bandera para activar o desactivar el registro")]
    [Display(Name = "Activo")]
    [Required(ErrorMessage = "El campo \"{0}\" es obligatorio")]
    public bool Activo { get; set; }
}
