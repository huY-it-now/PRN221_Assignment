using Can_BusinessObject;

namespace Can_Service
{
    public interface ICandidateService
    {
        public bool AddCandidateProfile(CandidateProfile candidate);
        public bool DeleteCandidate(CandidateProfile candidate);
        public List<CandidateProfile> GetCandidates();
        public CandidateProfile GetId(string id);
        public bool UpdateCandidate(CandidateProfile candidate);
        public List<CandidateProfile> SearchByName(string name);
    }
}
