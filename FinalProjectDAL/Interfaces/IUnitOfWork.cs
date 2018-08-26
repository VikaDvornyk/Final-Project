using System;
using System.Collections.Generic;
using FinalProjectDAL.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Question> Questions { get; }
        //IRoleRepository Roles { get; }
        void Save();
    }
}
