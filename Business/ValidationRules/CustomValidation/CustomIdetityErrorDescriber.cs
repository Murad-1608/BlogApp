using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.CustomValidation
{
    public class CustomIdetityErrorDescribe : IdentityErrorDescriber
    {
        
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "InvalidUserName",
                Description = $"{userName} adında istifadəçi mövcuddur"
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = "InvalidUserName",
                Description = $"{email} mövcuddur"
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parol ən az {6} simvol ola bilər"
            };
        }
    }
}
