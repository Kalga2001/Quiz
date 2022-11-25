using StefaniniQuiz.Domain.EntityInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StefaniniQuiz.Domain.Entity
{
    public class Quiz : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TechnologyName { get; set; }
        public ICollection<Questions> Questions { get; set; }
        public ICollection<QuizResults>? QuizResults { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
