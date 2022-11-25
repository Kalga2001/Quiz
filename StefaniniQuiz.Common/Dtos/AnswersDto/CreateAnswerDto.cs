using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Common.Dtos.AnswersDto
{
    public class CreateAnswerDto
    {
        public string AnswerText { get; set; }
        public int Point { get; set; }
        public bool IsCorrect { get; set; }
    }
}
