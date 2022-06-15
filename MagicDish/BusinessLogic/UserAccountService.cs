namespace BusinessLogic
{
    public class UserAccountService
    {
        public static List<UserAccount> Users { get; set; }
        

        public static List<UserAccount> GetUsers()
        {
            return Users;
        }

        public static void AddUser(UserAccount user)
        {
            Users.Add(user);
        }
    }
}
