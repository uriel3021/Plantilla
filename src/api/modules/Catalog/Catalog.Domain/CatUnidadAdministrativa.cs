using System.ComponentModel.DataAnnotations;
using Fgr.Sasp.Domain.Catalog;
using FSH.Starter.WebApi.Catalog.Domain.Events;
using Microsoft.EntityFrameworkCore;
namespace FSH.Starter.WebApi.Catalog.Domain;

[Display(Name = "Catálogo de unidades administrativas")]

public class CatUnidadAdministrativa : CatalogoBase
{

    [Comment("Abreviación de Unidad Administrativa")]
    [Display(Name = "Siglas")]
    [Required(ErrorMessage = "El campo \"{0}\" es obligatorio")]
    [MaxLength(15, ErrorMessage = "La longitud máxima para {0} es de {1} caracteres")]
    public string? DesCorta { get; set; }

    [Comment("Clave Presupuestal de Unidad Administrativa")]
    [Display(Name = "ClavePresupuestal")]
    [Required(ErrorMessage = "El campo \"{0}\" es obligatorio")]
    [MaxLength(10, ErrorMessage = "La longitud máxima para {0} es de {1} caracteres")]
    public string ClavePresupuestal { get; set; }

    private CatUnidadAdministrativa() { }

      private CatUnidadAdministrativa(Guid id, string desCorta, string descripcion, string clavePresupuestal )
    {
        Id = id;
        DesCorta = desCorta;
        Descripcion = descripcion;
        ClavePresupuestal = clavePresupuestal;

        QueueDomainEvent(new CatUnidadAdministrativaCreated { CatUnidadAdministrativa = this });
    }




    public static CatUnidadAdministrativa Create(string desCorta, string descripcion, string clavePresupuestal )
    {
        return new CatUnidadAdministrativa(Guid.NewGuid(), desCorta, descripcion, clavePresupuestal );
    }
}
