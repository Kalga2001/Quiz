using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StefaniniQuiz.Common.Dtos.QuestionsDto;

namespace StefaniniQuiz.Common.Dtos.QuizDtos.Dtos
{
    public class CreateQuizDto
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        public string TechnologyName { get; set; }

        public IEnumerable<CreateQuestionDto> Questions { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
