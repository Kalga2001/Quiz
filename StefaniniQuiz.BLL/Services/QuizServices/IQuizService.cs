using StefaniniQuiz.Common.Dtos.QuizDtos.Dtos;
using StefaniniQuiz.Common.Dtos.QuizDtos.ResultQuizDtos;
using StefaniniQuiz.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.BLL.Services.QuizServices
{
    public interface IQuizService
    {
        Task<Quiz> CreateQuiz(CreateQuizDto quiz);
        Task<Quiz> GetQuiz(Guid id);
        Task<ICollection<Quiz>> GetQuizzes();
        Task EditQuiz(Quiz editQuizDTO);
    }
}
