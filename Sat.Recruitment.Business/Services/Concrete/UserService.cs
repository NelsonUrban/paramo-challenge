using AutoMapper;
using Sat.Recruitment.Business.Dtos;
using Sat.Recruitment.Business.Services.Abstract;
using Sat.Recruitment.Custom.Exceptions;
using Sat.Recruitment.Custom.Validations;
using Sat.Recruitment.Custom.Validatiors;
using Sat.Recruitment.DataAccess.Repositories;
using Sat.Recruitment.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMoneyService _moneyService;

        public UserService(IUserRepository userRepository, IMapper mapper, IMoneyService moneyService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _moneyService = moneyService;
        }
        public async Task<UserReponseDto> CreateUser(CreateUserDto userDto)
        {
            var userValidator = new CreateUserValidator();
            var validResult = await userValidator.ValidateAsync(userDto);

            if (!validResult.IsValid)
            {
                throw new UserException(validResult.Errors.First().ErrorMessage.ToString());              
            }           

            userDto.Money = _moneyService.UserMoneyValidation(userDto.UserType, userDto.Money);

            User user = _mapper.Map<User>(userDto);

            if (!await IsDuplicated(user))
            {
                var userCreated = _userRepository.CreateUser(user);
                return _mapper.Map<UserReponseDto>(userCreated);
            }
            else
            {
                throw new UserException(Message.UserMessage.Duplicated);              
            }
        }
        private async Task<IEnumerable<UserReponseDto>> GetAllasync()
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserReponseDto>>(users);
        }
        private async Task<bool> IsDuplicated(User user)
        {
            var resultUsers = await GetAllasync();

            var users = _mapper.Map<List<User>>(resultUsers);

            var userValidators = new UserValidator(users);

            return userValidators.IsDuplicated(user);
        }
    }
}
