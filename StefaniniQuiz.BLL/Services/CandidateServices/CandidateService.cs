using Microsoft.EntityFrameworkCore;
using StefaniniQuiz.Common.Dtos.CandidatesDto.Dtos;
using StefaniniQuiz.DAL.Interfaces;
using StefaniniQuiz.Domain.Entity;
using StefaniniQuiz.Domain.EntityInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            var all = candidates.Where(x => x.IsActive == true && x.IsDeleted == false).ToList();
            return all;
        }

        public async Task<Candidate> GetByIdCandidate(Guid id)
        {
            var candidate = await _repository.GetByIdAsync(id);
            if (candidate.IsDeleted == true && candidate.IsActive == false)
            {
                throw new Exception("Candidate is deleted");
                return null;
            }
            else
            {
                return candidate;
            }
        }
    

        public async Task<Candidate> UpdateCandidate(Guid id,UpdateCandidateDto updateCandidate)
        {
            var candidate= await GetByIdCandidate(id);
           
            if (candidate.IsDeleted == true && candidate.IsActive == false)
            {
                throw new Exception("Candidate is deleted");
                return null;
            }
            else
            {
                return candidate;
            }

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
            candidate.IsActive = true;
            candidate.IsDeleted = false;
            await _repository.AddAsync(candidate);

            return candidate;
            
        }

        public async Task<Candidate> DeleteCandidate(Guid id)
        {
            var candidate = await _repository.GetByIdAsync(id); 
            if (candidate == null)
            {
                throw new ValidationException($"Object  with id {id} not found");
            }

            if (candidate.IsDeleted == true && candidate.IsActive == false)
            {
                return candidate;
            }

            else
            {
                candidate.IsActive = false;
                candidate.IsDeleted = true;
            }
            _repository.Update(candidate);
            
            return candidate;
        }
    }
}
