using AutoMapper;
using FinalProject.Models;
using FinalProjectBLL.DTO;
using FinalProjectBLL.Interfaces;
using FinalProjectBLL.Services;
using FinalProjectDAL.Interfaces;
using FinalProjectDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        //static string connectionString = "Data Source=(LocalDB)/MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True";
        //static private readonly IUnitOfWork uow = new EFUnitOfWork(connectionString);
        //IUserService userService = new UserService(uow);
        public HomeController()
        {
        }
        //public HomeController(IUserService serv)
        //{
        //    userService = serv;
        //}
        public ActionResult Index()
        {
            //IEnumerable<UserDTO> userDtos = userService.GetUsers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
           // var phones = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDtos);
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}