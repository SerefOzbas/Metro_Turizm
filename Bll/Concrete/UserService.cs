using Bll.Abstract;
using Dal.Abstract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Concrete
{
    public class UserService : IUserService
    {
        IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Delete(User entity)
        {
            _userDal.Remove(entity);
        }

        public void DeleteById(int entityID)
        {
            User user = _userDal.Get(a => a.ID == entityID);
            Delete(user);
        }

        public User Get(int entityID)
        {
            return _userDal.Get(a => a.ID == entityID);
        }

        public ICollection<User> GetAll()
        {
            return _userDal.GetAll().ToList();
        }

        public User GetUserByLogin(string email, string password)
        {
            return _userDal.Get(a => a.Email == email && a.Password == password);
        }

        public void Insert(User entity)
        {
            _userDal.Add(entity);
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }
    }
}
