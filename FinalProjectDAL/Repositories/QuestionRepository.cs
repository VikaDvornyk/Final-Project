using FinalProjectDAL;
using FinalProjectDAL.Database;
using FinalProjectDAL.Entities;
using FinalProjectDAL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDTO.Repositories
{
    public class QuestionRepository:IRepository<Question>
    {
        private UserContext db;

        public QuestionRepository(UserContext context)
        {
            this.db = context;
        }

        public IEnumerable<Question> GetAll()
        {
            var a = db.Questions.ToList();
            return db.Questions;
        }

        public Question Get(int id)
        {
            return db.Questions.Find(id);
        }

        public void Create(Question question)
        {
            db.Questions.Add(question);
        }

        public void Update(Question question)
        {
            db.Entry(question).State = EntityState.Modified;
        }

        public IEnumerable<Question> Find(Func<Question, Boolean> predicate)
        {
            return db.Questions.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Question question = db.Questions.Find(id);
            if (question != null)
                db.Questions.Remove(question);
        }
        public IdentityResult Register(AccountModelDAL model) { return null; }
    }
}
