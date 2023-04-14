using FluentValidation;
using Sat.Recruitment.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Custom.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        private readonly IList<User> users;
        public UserValidator(IList<User> users)
        {
            this.users = users;
        }
        public bool ExistByPhoneAndEmail(User user)
        {
            return users.Any(u => u.Phone.ToLower() == user.Phone.ToLower() || u.Email.ToLower() == user.Email.ToLower());            
        }

        public bool ExistByNameAndAddress(User user)
        {
            return users.Any(u => u.Name.ToLower() == user.Name.ToLower() && u.Address.ToLower() == user.Address.ToLower());
        }

        public bool IsDuplicated(User user)
        {
            return ExistByPhoneAndEmail(user) || ExistByNameAndAddress(user);
        }
    }
}
