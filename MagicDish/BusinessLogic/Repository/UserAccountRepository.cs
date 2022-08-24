using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        static List<UserAccount> _users = new List<UserAccount>
        {
            new UserAccount("user1", "user1@gmail.com", "password1"),
            new UserAccount("user2", "user2@gmail.com", "password2"),
        };

        public Task<List<UserAccount>> GetAsync()
        {
            return Task.FromResult<List<UserAccount>>(_users);
        }
    }
}
