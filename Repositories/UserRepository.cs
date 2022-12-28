using UserAuthenticationJWTGenerated.Data;
using UserAuthenticationJWTGenerated.Models;

namespace UserAuthenticationJWTGenerated.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext _context;
        public UserRepository(UsersContext context) 
        {
            _context = context;
        }
        public Users Create(Users vulunteerRegister)
        {
            _context.Users.Add(vulunteerRegister);
            vulunteerRegister.Id =_context.SaveChanges();
            return vulunteerRegister;
        }

        public Users GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public Users GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
