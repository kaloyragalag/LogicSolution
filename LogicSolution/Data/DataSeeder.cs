using LogicSolution.Model;
using System.Collections.Generic;
using System.Linq;

namespace LogicSolution.Data
{
    public class DataSeeder
    {
        private readonly DataContext _dataContext
            ;

        public DataSeeder(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void Seed()
        {
            if (!_dataContext.Users.Any())
            {
                var lstUsers = new List<User>()
                {
                        new User()
                        {
                            UserName = "admin",
                            Password = "admin",
                            FirstName = "admin",
                            LastName = "admin",
                            Email = "admin@admin.com"
                        }
                };

                _dataContext.Users.AddRange(lstUsers);
                _dataContext.SaveChanges();
            }
        }
    }
}
