using StefaniniQuiz.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Common.Dtos.QuizDtos.ResultQuizDtos
{
    public class ResultGetQuizByIdDto
    {
        public ResultGetQuizByIdDto()
        {
            Quiz = new Quiz();
            Code = 0;
            Status = string.Empty;
        }

        public Quiz Quiz { get; set; }
        public int Code { get; set; }

        public string Status { get; set; }
    }
}
