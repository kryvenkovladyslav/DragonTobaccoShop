using Microsoft.AspNetCore.Identity;

namespace Abstractions.Models
{
    public interface IRoleModel<TRole> where TRole : IdentityRole<Guid> { }
}