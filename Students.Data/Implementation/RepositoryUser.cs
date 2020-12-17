using Students.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Students.Data.Implementation
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly UserContext context;

        public RepositoryUser(UserContext context)
        {
            this.context = context;
        }
        public void Add(User s)
        {
            context.Add(s);
        }

        public void Delete(User s)
        {
            throw new NotImplementedException();
        }

        public User FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByUsernameAndPassword(User user)
        {
            return context.Users.Single(u => u.Username == user.Username && u.Password == user.Password);
        }

        public List<User> Search(Expression<Func<User, bool>> pred)
        {
            return context.Users.Where(pred).ToList();
        }
    }
}
