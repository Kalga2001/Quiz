using StefaniniQuiz.Common.Dtos.CandidatesDto.Dtos;
using StefaniniQuiz.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.BLL.Services.CandidateServices
{
    public interface ICandidateService
    {
        Task<ICollection<Candidate>> GetAllCandidates();
        Task<Candidate> GetByIdCandidate (Guid id);
        Task<Candidate> CreateCandidate(CreateCandidateDto createCandidateDto);
        Task<Candidate> UpdateCandidate(Guid id,UpdateCandidateDto updateCandidateDto);

        Task<Candidate> DeleteCandidate(Guid id);
    }
}
