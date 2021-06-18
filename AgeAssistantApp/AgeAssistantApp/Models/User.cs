namespace SearchApp.Models
{
    public class User
    {
        public User(string uname, string passwd)
        {
            Username = uname;
            Password = passwd;
        }

        public string Username { get; set; }
        
        public string Password { get; set; }
    }
}
