using FinalProjectBLL.Interfaces;
using FinalProjectBLL.Services;
using FinalProjectDAL.Interfaces;
using FinalProjectDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class QuizController : ApiController
    {

        [HttpGet]
        [Route("api/Questions")]
        public HttpResponseMessage GetQuestions()
        {
            // string connectionString = "Data Source=(LocalDB)/MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True";
            //IUnitOfWork uow = new EFUnitOfWork(connectionString);
            //IQuestionService questionService = new QuestionService(uow);
            //SqlConnection conn = new SqlConnection(connectionString);
            //conn.Open();
            using (DefaultConnectionEntities db = new DefaultConnectionEntities())
            {
                var Qns = db.Question.Select(x => new { QnID = x.Id, Qn = x.Qn, x.Option1, x.Option2, x.Option3, x.Option4 }).ToArray();
                var updated = Qns.AsEnumerable()
                    .Select(x => new
                    {
                        QnID = x.QnID,
                        Qn = x.Qn,
                        Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 }
                    }).ToList();
                //conn.Close();
                return this.Request.CreateResponse(HttpStatusCode.OK, updated);
            }
        }
    }
}
