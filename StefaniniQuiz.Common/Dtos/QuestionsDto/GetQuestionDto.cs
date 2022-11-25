using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StefaniniQuiz.Common.Dtos.AnswersDto;

namespace StefaniniQuiz.Common.Dtos.QuestionsDto
{
    public class GetQuestionDto
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }

        public int TotalPoints { get; set; }

        public IEnumerable<GetAnswerDto> Answers { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
