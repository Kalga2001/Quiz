using StefaniniQuiz.Domain.EntityInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StefaniniQuiz.Domain.Entity
{
    public class QuizResults : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int TotalPoints { get; set; }
        public string ResultJson { get; set; }
        [JsonIgnore]
        public Quiz? Quiz { get; set; }
        [JsonIgnore]
        public Candidate? Candidate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

    }
}
