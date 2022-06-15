namespace BusinessLogic
{
    public class UserAccount
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Username { get; set; }
        public string Password { get; set; }
        public FoodRepository FoodRepository { get; set; } 

        public UserAccount()
        {
        }

        public UserAccount(string name, string username, string email, string password)
        {
            Name = name;
            Email = email;
            Username = username;
            Password = password;
        }
    }
}
