using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StefaniniQuiz.Common.Dtos.QuizDtos.Dtos;
using StefaniniQuiz.Common.Dtos.QuizDtos.ResultQuizDtos;
using StefaniniQuiz.DAL.Interfaces;
using StefaniniQuiz.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace StefaniniQuiz.BLL.Services.QuizServices
{
    public class QuizServices : IQuizService
    {
        private readonly IGenericRepository<Quiz> _quizRepository;
        private readonly IGenericRepository<Questions> _questionRepository;
        private readonly IGenericRepository<Answers> _answerRepository;

        public QuizServices(IGenericRepository<Quiz> quizRepository, IGenericRepository<Questions> questionRepository, IGenericRepository<Answers> answerRepository)
        {
            _quizRepository = quizRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }


        public async Task<Quiz> CreateQuiz(CreateQuizDto data)
        {
            var quiz = new Quiz()
            {
                //Id = data.Id ?? Guid.NewGuid(),
                Title = data.Title,
                TechnologyName = data.TechnologyName,
                CreatedDate = DateTime.Now,

                Questions = data.Questions.Select(x => new Questions
                {
                    //Id = Guid.NewGuid(),
                    QuestionText=x.QuestionText,
                    Answers = x.Answers.Select(y => new Answers
                    {
                        IsCorrect = y.IsCorrect,
                        Point = y.Point,
                        AnswerText = y.AnswerText


                    }).ToList()
                }).ToList()
            };

            await _quizRepository.AddAsync(quiz);
            return quiz;
        }

        public async Task EditQuiz(Quiz editedQuiz)
        {

            var existingQuiz = await GetQuiz(editedQuiz.Id);

            if (existingQuiz is null)
            {
                throw new Exception("Quiz not found.");
            }


            existingQuiz = await _quizRepository.SetValues(existingQuiz, editedQuiz);

            //Delete
            foreach (var existingQuestion in existingQuiz.Questions.ToList())
            {
                if (!editedQuiz.Questions.Any(c => c.Id == existingQuestion.Id))
                {
                    foreach (var existingAnswer in existingQuestion.Answers)
                    {
                        await _answerRepository.DeleteAsync(existingAnswer);
                    }

                    await _questionRepository.DeleteAsync(existingQuestion);
                }
                else
                {
                    foreach (var existingAnswer in existingQuestion.Answers)
                    {
                        var editedQuestion = editedQuiz.Questions.Where(q => q.Id == existingQuestion.Id).FirstOrDefault();
                        if (editedQuestion is null) continue;

                        if (!editedQuestion.Answers.Any(c => c.Id == existingAnswer.Id))
                        {
                            await _answerRepository.DeleteAsync(existingAnswer);
                        }
                    }
                }
            }


            //Update and insert childrens

            foreach (var questionEdited in editedQuiz.Questions)
            {
                var existingQuestion = existingQuiz.Questions
                    .Where(q => q.Id == questionEdited.Id)
                    .FirstOrDefault();


                if (existingQuestion is null)
                {
                    existingQuestion = new Questions
                    {
                        Id = questionEdited.Id,
                        Answers = questionEdited.Answers,
                        QuizId = questionEdited.QuizId,
                        QuestionText = questionEdited.QuestionText

                    };

                    existingQuiz.Questions.Add(existingQuestion);
                }
                else
                {
                    existingQuestion = await _questionRepository.SetValues(existingQuestion, questionEdited);
                }

                foreach (var answerEdited in questionEdited.Answers)
                {
                    var existingAnswer = existingQuestion.Answers
                        .Where(a => a.Id == answerEdited.Id)
                        .FirstOrDefault();

                    if (existingAnswer != null)
                    {
                        existingAnswer = await _answerRepository.SetValues(existingAnswer, answerEdited);
                        await _answerRepository.Update(existingAnswer);
                    }
                    else
                    {
                        var newAnswer = new Answers
                        {
                            //Id = answerEdited.Id,
                            AnswerText = answerEdited.AnswerText,
                            IsCorrect = answerEdited.IsCorrect,
                            Point = answerEdited.Point,
                            QuestionId = answerEdited.QuestionId,
                        };
                        existingQuestion.Answers.Add(newAnswer);
                    }

                }
                await _questionRepository.Update(existingQuestion);



            }
            await _quizRepository.Update(existingQuiz);



        }

        public async Task<Quiz> GetQuiz(Guid id)
        {

            var quiz = await _quizRepository.GetByIdAsync(id, include: source => source.Include(q => q.Questions).ThenInclude(q => q.Answers));

            return quiz;
        }

        public async Task<ICollection<Quiz>> GetQuizzes()
        {
            var quiz = await _quizRepository.GetAllAsync(include: source => source.Include(q => q.Questions).ThenInclude(a => a.Answers));
            return quiz;
        }



    }
}