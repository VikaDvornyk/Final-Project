using FinalProject.Models;
using FinalProjectBLL.DTO;
using FinalProjectBLL.Interfaces;
using FinalProjectBLL.Services;
using FinalProjectDAL.Interfaces;
using FinalProjectDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class UserController : ApiController
    {
        static string connectionString = "Data Source=(LocalDB)/MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True";
        static private readonly IUnitOfWork uow = new EFUnitOfWork(connectionString);
        IUserService userService = new UserService(uow);
        [HttpPost]
        [Route("api/InsertUser")]
        public UserViewModel Insert(UserViewModel user)
        {
            UserDTO userDTO = new UserDTO();
            userDTO.Email = user.Email;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.UserName = user.UserName;
            userDTO.Score = user.Score;
            
            userService.MakeUser(userDTO);
            return user;
        }

        [HttpPost]
        [Route("api/SetScore")]
        public UserViewModel InsertScore(UserViewModel user)
        {
            var userDTO = userService.GetUserByUserName(user.UserName);
            userDTO.Score = user.Score;

            userService.SetScore(userDTO);
            return user;
        }
    }
}
