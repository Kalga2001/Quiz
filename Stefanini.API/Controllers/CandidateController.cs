using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StefaniniQuiz.BLL.Services.CandidateServices;
using StefaniniQuiz.Common.Dtos.CandidatesDto.Dtos;
using StefaniniQuiz.Domain.Entity;

namespace LikeQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;
        public CandidateController(ICandidateService service)
        {
            _service = service;
        }

        [HttpGet("GetAllCandidates")]
        public async Task<ICollection<Candidate>> GetAll()
        {
            return await _service.GetAllCandidates();
        }


        [HttpGet("id")]
        public async Task<Candidate> GetById(Guid id)
        {
            return await _service.GetByIdCandidate(id);
        }

        [HttpPost("CreateCandidate")]
        public async Task<Candidate> CreateCandidate(CreateCandidateDto candidateDto)
        {
            var result=await _service.CreateCandidate(candidateDto);
            return result;
        }

        [HttpPut("UpdateCandidate")]
        public async Task<Candidate> UpdateCandidate(Guid id, UpdateCandidateDto candidateDto)
        {
            var result = await _service.UpdateCandidate(id, candidateDto);
            return result;
        }


    }
}
