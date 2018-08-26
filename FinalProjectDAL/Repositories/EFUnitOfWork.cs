using FinalProjectDAL.Database;
using FinalProjectDAL.Entities;
using FinalProjectDAL.Interfaces;
using FinalProjectDTO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private UserContext db;
        private UserRepository userRepository;
        //private RoleRepository roleRepository;
        private QuestionRepository questionRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new UserContext(connectionString);
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new QuestionRepository(db);
                return questionRepository;
            }
        }
        //public IRoleRepository Roles
        //{
        //    get
        //    {
        //        if (roleRepository == null)
        //            roleRepository = new RoleRepository(db);
        //        return roleRepository;
        //    }
        //}

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
