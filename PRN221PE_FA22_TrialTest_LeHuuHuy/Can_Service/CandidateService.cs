using Can_BusinessObject;
using Can_Repository;

namespace Can_Service
{
    public class CandidateService : ICandidateService
    {
        private ICandidateRepo candidateRepo;

        public CandidateService()
        {
            candidateRepo = new CandidateRepo();
        }

        public bool AddCandidateProfile(CandidateProfile candidate)
        {
            return candidateRepo.AddCandidateProfile(candidate);
        }

        public bool DeleteCandidate(CandidateProfile candidate)
        {
            return candidateRepo.DeleteCandidate(candidate);
        }

        public List<CandidateProfile> GetCandidates()
        {
            return candidateRepo.GetCandidates();
        }

        public CandidateProfile GetId(string id)
        {
            return candidateRepo.GetId(id);
        }

        public List<CandidateProfile> SearchByName(string name)
        {
            return candidateRepo.SearchByName(name);
        }

        public bool UpdateCandidate(CandidateProfile candidate)
        {
            return candidateRepo.UpdateCandidate(candidate);
        }
    }
}
