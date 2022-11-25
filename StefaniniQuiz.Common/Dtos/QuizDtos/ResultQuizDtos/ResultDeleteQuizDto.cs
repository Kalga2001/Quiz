using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Common.Dtos.QuizDtos.ResultQuizDtos
{
    public class ResultDeleteQuizDto
    {
        public ResultDeleteQuizDto()
        {
            IsDeleted = false;
            Code = 0;
            Status = string.Empty;
        }

        public int Code { get; set; }

        public string Status { get; set; }

        public bool IsDeleted { get; set; }
    }
}
