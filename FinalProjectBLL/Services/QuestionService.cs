using AutoMapper;
using FinalProjectBLL.DTO;
using FinalProjectBLL.Interfaces;
using FinalProjectDAL.Entities;
using FinalProjectDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBLL.Services
{
    public class QuestionService:IQuestionService
    {
        IUnitOfWork Database { get; set; }

        public QuestionService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeQuestion(QuestionDTO questionDto)
        {
            //Role role = Database.Roles.Get(userDto.RoleId);
            Question question = new Question
            {
                Qn = questionDto.Qn,
                Option1 = questionDto.Option1,
                Option2 = questionDto.Option2,
                Option3 = questionDto.Option3,
                Option4 = questionDto.Option4,
            };
            Database.Questions.Create(question);
            Database.Save();
        }
        
        public IEnumerable<QuestionDTO> GetQuestions()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Question, QuestionDTO>()).CreateMapper();
            var a = Database.Questions.GetAll().ToList();
            return mapper.Map<IEnumerable<Question>, List<QuestionDTO>>(Database.Questions.GetAll());
        }

        public QuestionDTO GetQuestion(int? id)
        {
            if (id == null)
                throw new ValidationException("No id for User");
            var question = Database.Questions.Get(id.Value);
            return new QuestionDTO { Qn = question.Qn, Option1 = question.Option1, Option2 = question.Option1, Option3 = question.Option1, Option4 = question.Option1 };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
