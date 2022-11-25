using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Common.Dtos.QuizDtos.ResultQuizDtos
{
    public class ResultCreateQuizDto
    {
        public ResultCreateQuizDto()
        {
            IsCreated = false;
            Code = 0;
            Status = string.Empty;
        }

        public int Code { get; set; }

        public string Status { get; set; }

        public bool IsCreated { get; set; }
    }
}
