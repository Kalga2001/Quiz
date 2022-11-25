using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StefaniniQuiz.Common.Dtos.QuestionsDto;

namespace StefaniniQuiz.Common.Dtos.QuizDtos.Dtos
{
    public class GetQuizDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string TechnologyName { get; set; }

        public IEnumerable<GetQuestionDto> Questions { get; set; } = Enumerable.Empty<GetQuestionDto>();
        public DateTime? CreatedDate { get; set; }


    }
}
