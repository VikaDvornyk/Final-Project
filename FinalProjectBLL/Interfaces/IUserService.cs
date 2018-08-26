using FinalProjectBLL.DTO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBLL.Interfaces
{
    public interface IUserService
    {
        void MakeUser(UserDTO userDto);
        UserDTO GetUser(int? id);
        IEnumerable<UserDTO> GetUsers();
        IdentityResult Register(AccountModelDTO model);
        IEnumerable<QuestionDTO> GetQuestions();
        UserDTO GetUserByUserName(string un);
        void SetScore(UserDTO userDto);
        void GetRoles();
        void Dispose();
    }
}
