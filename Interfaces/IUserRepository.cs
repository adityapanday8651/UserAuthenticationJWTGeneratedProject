using UserAuthenticationJWTGenerated.Models;

namespace UserAuthenticationJWTGenerated.Repositories
{
    public interface IUserRepository
    {
        Users Create(Users users);
        Users GetByEmail(string email);
        Users GetById(int id);
    }
}
