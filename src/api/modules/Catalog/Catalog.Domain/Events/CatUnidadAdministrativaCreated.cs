
using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events
{
    // Contexto compartido para seeds
    public static class SeedEventBus
    {
        public static CatUnidadAdministrativaCreated? UnidadEvent { get; set; }
    }

    public sealed record CatUnidadAdministrativaCreated : DomainEvent
    {
        public CatUnidadAdministrativa? CatUnidadAdministrativa { get; set; }
    }
}
