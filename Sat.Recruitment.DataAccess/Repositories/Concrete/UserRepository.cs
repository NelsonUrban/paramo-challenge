using Sat.Recruitment.Custom.Services.Abstract;
using Sat.Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.DataAccess.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private const string FILE_NAME = "Users.txt";
        private const string FOLDER_NAME = "Files";
        private readonly List<User> _users = new List<User>();
        private readonly IFileService _fileService;
        public UserRepository(IFileService fileService)
        {
            _fileService = fileService;
        }
        public User CreateUser(User user)
        {
            _users.Add(user);
            return user;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var userResult = new List<User>();

            using var reader = _fileService.ReadFile(FOLDER_NAME, FILE_NAME);

            while (reader.Peek() >= 0)
            {
                var line = await reader.ReadLineAsync();
                var userMapping = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = (line.Split(',')[4].ToString()),
                    Money = Convert.ToDecimal(line.Split(',')[5]),
                };

                userResult.Add(userMapping);
            }
            reader.Close();

            return userResult;
        }
    }
}
