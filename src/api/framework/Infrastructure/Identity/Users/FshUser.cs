using System.ComponentModel.DataAnnotations.Schema;
using FSH.Starter.WebApi.Catalog.Domain;
using Microsoft.AspNetCore.Identity;

namespace FSH.Framework.Infrastructure.Identity.Users;
public class FshUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Uri? ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

    public string? ObjectId { get; set; }
    public Guid UAId { get; set; }
    [NotMapped]
    public virtual string Roles { get; set; }
}
