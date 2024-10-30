using Can_BusinessObject;

namespace Can_Repository
{
    public interface ICandidateRepo
    {
        public CandidateProfile GetId(string id);
        public List<CandidateProfile> GetCandidates();
        public bool AddCandidateProfile(CandidateProfile candidate);
        public bool DeleteCandidate(CandidateProfile candidate);
        public bool UpdateCandidate(CandidateProfile candidate);
        public List<CandidateProfile> SearchByName(string name);
    }
}
