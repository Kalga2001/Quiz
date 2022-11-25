using StefaniniQuiz.Domain.EntityInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StefaniniQuiz.Domain.Entity
{
    public class Answers : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string AnswerText { get; set; }
        public int Point { get; set; }

        public bool IsCorrect { get; set; }

        public Guid QuestionId { get; set; }
        [JsonIgnore]
        public Questions? Question { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
