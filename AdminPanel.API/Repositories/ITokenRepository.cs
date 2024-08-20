using Microsoft.AspNetCore.Identity;

namespace AdminPanel.API.Repositories
{
    public interface ITokenRepository
    {
        string GenerateToken(IdentityUser user);
    }
}
