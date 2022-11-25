using StefaniniQuiz.Common.Dtos.AnswersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Common.Dtos.QuestionsDto
{
    public class EditQuestionsDto
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }

        public int TotalPoints { get; set; }

        public IEnumerable<EditAnswerDto> Answers { get; set; }
    }
}
