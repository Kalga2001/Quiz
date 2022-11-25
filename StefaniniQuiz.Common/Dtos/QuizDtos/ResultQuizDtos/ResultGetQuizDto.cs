using StefaniniQuiz.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Common.Dtos.QuizDtos.ResultQuizDtos
{
    public class ResultGetQuizDto
    {
        public ResultGetQuizDto()
        {
            Quiz = new List<Quiz>();
            Code = 0;
            Status = string.Empty;
        }

        public ICollection<Quiz> Quiz { get; set; }
        public int Code { get; set; }

        public string Status { get; set; }
    }
}
