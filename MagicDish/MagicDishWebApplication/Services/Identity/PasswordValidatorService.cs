using MagicDishWebApplication.Models;
using Microsoft.AspNetCore.Identity;


//using Microsoft.AspNet.Identity;

namespace MagicDishWebApplication.Services.Identity
{
    public class PasswordValidatorService : IPasswordValidator<MagicDishWebApplicationUser>
    {

        public Task<IdentityResult> ValidateAsync(UserManager<MagicDishWebApplicationUser> manager, MagicDishWebApplicationUser user, string password)
        {
            if (password.Contains(user.Email))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "Email address used",
                    Description = "You can't use email address as password!"
                }));
            };
            return Task.FromResult(IdentityResult.Success);
        }
    }
}