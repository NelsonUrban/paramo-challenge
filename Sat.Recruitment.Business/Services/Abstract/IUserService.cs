using Sat.Recruitment.Business.Dtos;
using Sat.Recruitment.Business.Models;
using System.Threading.Tasks;

namespace Sat.Recruitment.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<UserReponseDto> CreateUser(CreateUserDto userDto);
    }
}
