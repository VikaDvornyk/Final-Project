using FinalProjectBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBLL.Interfaces
{
    public interface IQuestionService
    {
        void MakeQuestion(QuestionDTO userDto);
        QuestionDTO GetQuestion(int? id);
        IEnumerable<QuestionDTO> GetQuestions();
        void Dispose();
    }
}
