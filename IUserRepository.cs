using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetAllUsers();
        User GetUser(int id);        
        bool Delete(int id);
    }
}

