using StefaniniQuiz.Common.Dtos.QuestionsDto;
using StefaniniQuiz.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Common.Dtos.QuizDtos.Dtos
{
    public class EditQuizDto
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string TechnologyName { get; set; }

        public IEnumerable<EditQuestionsDto> Questions { get; set; } = Enumerable.Empty<EditQuestionsDto>();

        public DateTime? CreateDate { get; set; }
    }
}
