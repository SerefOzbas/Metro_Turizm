using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Abstract
{
    public interface IUserService : IBaseService<User>
    {
        User GetUserByLogin(string email, string password);
    }
}
