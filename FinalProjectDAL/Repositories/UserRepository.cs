using System;
using System.Collections.Generic;
using System.Linq;
using FinalProjectDAL.Entities;
using FinalProjectDAL.Database;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FinalProjectDAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FinalProjectDAL.Repositories
{
    public class UserRepository:IRepository<User>
    {
        private UserContext db;

        public UserRepository(UserContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
        public IdentityResult Register(AccountModelDAL model)
        {
            var userStore = new UserStore<User>(new UserContext());
            var manager = new UserManager<User>(userStore);
            var user = new User() { UserName = model.UserName, Email = model.Email };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };
            IdentityResult result = manager.Create(user, model.Password);
            var currentUser = manager.FindByName(user.UserName);
            manager.AddToRoles(currentUser.Id, model.Roles);
            return result;
        }
    }
}
