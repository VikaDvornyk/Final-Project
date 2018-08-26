using FinalProjectBLL.Interfaces;
using FinalProjectBLL.Services;
using FinalProjectDAL.Interfaces;
using FinalProjectDAL.Repositories;
using Ninject.Modules;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBLL.Infrastructure
{
    public class ServiceModule:NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
            
        }
    }
}
