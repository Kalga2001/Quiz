using StefaniniQuiz.Domain.EntityInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StefaniniQuiz.Domain.Entity
{
    public class Questions : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int TotalPoints => Answers.Any() ? Answers.Select(x => x.Point).Sum() : 0;

        public string QuestionText { get; set; }
        public ICollection<Answers> Answers { get; set; } = new List<Answers>();
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
       
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }



    }
}
