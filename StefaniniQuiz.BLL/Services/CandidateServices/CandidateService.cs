using Microsoft.EntityFrameworkCore;
using StefaniniQuiz.Common.Dtos.CandidatesDto.Dtos;
using StefaniniQuiz.DAL.Interfaces;
using StefaniniQuiz.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.BLL.Services.CandidateServices
{
    public class CandidateService : ICandidateService
    {
        private readonly IGenericRepository<Candidate> _repository;

        public CandidateService(IGenericRepository<Candidate> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Candidate>> GetAllCandidates()
        {
            var candidates = await _repository.GetAllAsync();
            return candidates;
        }

        public async Task<Candidate> GetByIdCandidate(Guid id)
        {
            var candidate = await _repository.GetByIdAsync(id);

            return candidate;
        }
    

        public async Task<Candidate> UpdateCandidate(Guid id,UpdateCandidateDto updateCandidate)
        {
            var candidate= await GetByIdCandidate(id);
            
            candidate.Email=updateCandidate.Email;
            candidate.FirstName=updateCandidate.FirstName;
            candidate.LastName=updateCandidate.LastName;
            candidate.UpdatedDate = DateTime.Now;
            candidate.UpdatedBy = Environment.UserName;

            _repository.Update(candidate);

            return candidate;
        }

        public async Task<Candidate> CreateCandidate(CreateCandidateDto createCandidateDto)
        {
            Candidate candidate = new Candidate();
            candidate.Id = new Guid();
            candidate.FirstName = createCandidateDto.FirstName;
            candidate.LastName = createCandidateDto.LastName;
            candidate.Email = createCandidateDto.Email;
            candidate.CreatedBy = Environment.UserName;
            candidate.CreatedDate= DateTime.Now;

            _repository.AddAsync(candidate);

            return candidate;
            
        }
    }
}
