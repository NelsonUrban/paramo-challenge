using Sat.Recruitment.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.DataAccess.Repositories
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
