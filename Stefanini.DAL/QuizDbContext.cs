using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using StefaniniQuiz.Domain.Entity;

namespace StefaniniQuiz.DAL
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext()
        {
        }

        public QuizDbContext(DbContextOptions<QuizDbContext> options)
            : base(options)
        {

        }



        public DbSet<Answers> Answers { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<QuizResults> QuizResults { get; set; }
    }
}
