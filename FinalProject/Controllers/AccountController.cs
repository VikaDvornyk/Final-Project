using FinalProject.Models;
using FinalProjectBLL.DTO;
using FinalProjectBLL.Interfaces;
using FinalProjectBLL.Services;
using FinalProjectDAL.Interfaces;
using FinalProjectDAL.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class AccountController : ApiController
    {
        static string connectionString = "Data Source=(LocalDB)/MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True";
        static public readonly IUnitOfWork uow = new EFUnitOfWork(connectionString);
        static public IUserService userService = new UserService(uow);

        public AccountController() { }

        //public AccountController(IUserService serv)
        //{
        //    userService = serv;
        //}
        [Route("api/User/Register")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(AccountModel model)
        {
            // conn = new SqlConnection(connectionString);
            //conn.Open();
            AccountModelDTO modelDTO = new AccountModelDTO();
            modelDTO.Email = model.Email;
            modelDTO.FirstName = model.FirstName;
            modelDTO.LastName = model.LastName;
            modelDTO.Password = model.Password;
            modelDTO.UserName = model.UserName;
            modelDTO.Roles = model.Roles;
            var result = userService.Register(modelDTO);
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
            //conn.Close();
            return result;
        }
        [HttpGet]
        //[Authorize]
        [Route("api/GetUserClaims")]
        public AccountModel GetUserClaims()
        {
            //string connectionString = "Data Source=(LocalDB)/MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True";
            //IUnitOfWork uow = new EFUnitOfWork(connectionString);
            //IUserService userService = new UserService(uow);
            //string connectionString = "Data Source=(LocalDB)/MSSQLLocalDB;Initial Catalog=DefaultConnection;Integrated Security=True";
            //SqlConnection conn = new SqlConnection(connectionString);
            //conn.Open();
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            //if(conn.State == ConnectionState.Open)
            //{
           // conn.Close();
            //}
            return model;
        }
    }
}
