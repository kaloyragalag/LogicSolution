namespace LogicSolution.Model
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserToken
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
