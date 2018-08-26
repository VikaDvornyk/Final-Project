using FinalProjectBLL.Interfaces;
using System;
using System.Collections.Generic;
using FinalProjectDAL.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectBLL.DTO;
using FinalProjectDAL.Entities;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using FinalProjectDAL.Repositories;

namespace FinalProjectBLL.Services
{
    public class UserService: IUserService
    {
        IUnitOfWork Database { get; set; }
       
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeUser(UserDTO userDto)
        {
            //Role role = Database.Roles.Get(userDto.RoleId);
            User user = new User
            {
                FirstName=userDto.FirstName,
                LastName=userDto.LastName
                //Email = userDto.Email,
                //Password = userDto.Password,
                //UserName = userDto.UserName,
                //RoleId = userDto.RoleId,
                //Role = role
            };
            Database.Users.Create(user);
            Database.Save();
        }

        public IdentityResult Register(AccountModelDTO model)
        {
            AccountModelDAL modelDAL = new AccountModelDAL();
            modelDAL.Email = model.Email;
            modelDAL.FirstName = model.FirstName;
            modelDAL.LastName = model.LastName;
            modelDAL.Password = model.Password;
            modelDAL.UserName = model.UserName;
            modelDAL.Roles = model.Roles;
            var result = Database.Users.Register(modelDAL);
            //var userStore = new UserStore<User>(new UserContext());
            //var manager = new UserManager<User>(userStore);
            //var user = new User() { UserName = model.UserName, Email = model.Email };
            //user.FirstName = model.FirstName;
            //user.LastName = model.LastName;
            //manager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 3
            //};
            //IdentityResult result = manager.Create(user, model.Password);
            return result;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("No id for User");
            var user = Database.Users.Get(id.Value);
            //if (user == null)
                //throw new ValidationException("User is nor found");

            return new UserDTO { FirstName=user.FirstName, LastName = user.LastName/*Email = user.Email, Password = user.Password, UserName = user.UserName, RoleId = user.RoleId*/ };
        }
        public UserDTO GetUserByUserName(string un)
        {
            if (un == null)
                throw new ValidationException("No UserName for User");
            var user = Database.Users.Find(x=>x.UserName == un).FirstOrDefault();
            //if (user == null)
            //throw new ValidationException("User is nor found");

            return new UserDTO { FirstName = user.FirstName, LastName = user.LastName/*Email = user.Email, Password = user.Password, UserName = user.UserName, RoleId = user.RoleId*/ };
        }
        public IEnumerable<QuestionDTO> GetQuestions()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Question, QuestionDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Question>, List<QuestionDTO>>(Database.Questions.GetAll());
        }

        public void SetScore (UserDTO userDto)
        {
            var user = Database.Users.Find(x => x.UserName == userDto.UserName).FirstOrDefault();
            user.Score = userDto.Score;
            Database.Users.Update(user);
            Database.Save();
        }

        public void GetRoles()
        {
            //Database.Roles.GetAllRoles();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
