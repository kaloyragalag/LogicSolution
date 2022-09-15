using LogicSolution.Model;

namespace LogicSolution.Services
{
    public interface IAuthorizeService
    {
        UserModel Authenticate(UserModel userModel);
        string GenerateToken(UserModel userModel);
    }
}
