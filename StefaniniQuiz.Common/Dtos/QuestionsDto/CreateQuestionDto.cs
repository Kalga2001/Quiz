using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StefaniniQuiz.Common.Dtos.AnswersDto;

namespace StefaniniQuiz.Common.Dtos.QuestionsDto
{
    public class CreateQuestionDto
    {
        public string QuestionText { get; set; }

        public int TotalPoints => Answers.Any() ? Answers.Select(x => x.Point).Sum() : 0;

        public IEnumerable<CreateAnswerDto> Answers { get; set; }

    }
}
