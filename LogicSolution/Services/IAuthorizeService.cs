using LogicSolution.Data;
using LogicSolution.Model;

namespace LogicSolution.Services
{
    public interface IAuthorizeService
    {
        User Authenticate(DataContext context, UserModel userModel);
        UserToken GenerateToken(User user);
    }
}
