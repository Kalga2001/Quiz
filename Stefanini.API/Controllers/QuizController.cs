using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StefaniniQuiz.BLL.Services.QuizServices;
using StefaniniQuiz.Common.Dtos.AnswersDto;
using StefaniniQuiz.Common.Dtos.QuestionsDto;
using StefaniniQuiz.Common.Dtos.QuizDtos.Dtos;
using StefaniniQuiz.Common.Dtos.QuizDtos.ResultQuizDtos;
using StefaniniQuiz.Domain.Entity;
using System.Net;

namespace LikeQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class QuizzesController : ControllerBase
        {
            private readonly IQuizService _quizServices;

            public QuizzesController(IQuizService quizServices)
            {
                _quizServices = quizServices;

            }

            [HttpGet]
            public async Task<ActionResult<GetQuizDto>> GetQuizzes()
            {

                var quizzes = (await _quizServices.GetQuizzes())
                    .Select(quiz => new GetQuizDto
                    {
                        Id = quiz.Id,
                        Title = quiz.Title,
                        TechnologyName = quiz.TechnologyName,
                        CreatedDate = quiz.CreatedDate,
                        Questions = quiz.Questions.Select(x => new GetQuestionDto
                        {
                            Id = x.Id,
                            QuestionText = x.QuestionText,
                            TotalPoints = x.TotalPoints,
                            Answers = x.Answers.Select(y => new GetAnswerDto
                            {
                                Id = y.Id,
                                AnswerText = y.AnswerText,
                                IsCorrect = y.IsCorrect,
                                Point = y.Point
                            })
                        })
                    });

                return Ok(quizzes);
            }

            //Paginare , o lista de 20 obiecte se transmite 
            // POst QuizDTO - Id la obiect ca return, status message OK , iD la obiect
            //Delete(guid id)


            [HttpGet("{id}")]
            public async Task<ActionResult<GetQuizDto>> GetQuiz(Guid id)
            {
                Quiz quiz = await _quizServices.GetQuiz(id);
                var getQuizDTO = new GetQuizDto()
                {
                    Id = quiz.Id,
                    Title = quiz.Title,
                    TechnologyName = quiz.TechnologyName,
                    CreatedDate=quiz.CreatedDate,
                    Questions = quiz.Questions.Select(x => new GetQuestionDto
                    {
                        Id = x.Id,
                        QuestionText = x.QuestionText,
                        TotalPoints = x.TotalPoints,
                        Answers = x.Answers.Select(y => new GetAnswerDto
                        {
                            Id = y.Id,
                            AnswerText = y.AnswerText,
                            IsCorrect = y.IsCorrect,
                            Point = y.Point
                        })
                    })
                };
                return Ok(getQuizDTO);
            }


            [HttpPost]
            public async Task<ActionResult> AddQuiz(CreateQuizDto data)
            {
                var createdQuiz = await _quizServices.CreateQuiz(data);

                var getQuizDTO = new GetQuizDto()
                {
                    Id = createdQuiz.Id,
                    Title = createdQuiz.Title,
                    TechnologyName = createdQuiz.TechnologyName,
                    CreatedDate = createdQuiz.CreatedDate,
                    Questions = createdQuiz.Questions.Select(x => new GetQuestionDto
                    {
                        Id = x.Id,
                        QuestionText= x.QuestionText,
                        TotalPoints = x.TotalPoints,
                        Answers = x.Answers.Select(y => new GetAnswerDto
                        {
                            Id = y.Id,
                            AnswerText = y.AnswerText,
                            IsCorrect = y.IsCorrect,
                            Point = y.Point
                        })
                    })
                };

                return CreatedAtAction(nameof(GetQuiz), new { id = createdQuiz.Id }, getQuizDTO);
            }

            [HttpPut]
            public async Task<ActionResult> EditQuiz(EditQuizDto editQuizDTO)
            {
                var editQuiz = new Quiz
                {
                    Id = editQuizDTO.Id,
                    Title = editQuizDTO.Title,
                    TechnologyName = editQuizDTO.TechnologyName,
                    CreatedDate=editQuizDTO.CreateDate,
                    Questions = editQuizDTO.Questions.Select(x => new Questions
                    {
                        Id = x.Id,
                        QuestionText=x.QuestionText,
                        QuizId = editQuizDTO.Id,
                        Answers = x.Answers.Select(y => new Answers
                        {
                            Id = y.Id,
                            QuestionId = x.Id,
                            AnswerText = y.AnswerText,
                            IsCorrect = y.IsCorrect,
                            Point = y.Point
                        }).ToList()
                    }).ToList()
                };


                await _quizServices.EditQuiz(editQuiz);

                return Ok();

            }
        }
    }
}