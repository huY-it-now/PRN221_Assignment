using Can_BusinessObject;
using Can_DAO;

namespace Can_Repository
{
    public class CandidateRepo : ICandidateRepo
    {
        public bool AddCandidateProfile(CandidateProfile candidate)
        {
            return CandidateDAO.Instance.AddCandidateProfile(candidate);
        }

        public bool DeleteCandidate(CandidateProfile candidate)
        {
            return CandidateDAO.Instance.DeleteCandidate(candidate);
        }

        public List<CandidateProfile> GetCandidates()
        {
            return CandidateDAO.Instance.GetCandidates();
        }

        public CandidateProfile GetId(string id)
        {
            return CandidateDAO.Instance.GetId(id);
        }

        public List<CandidateProfile> SearchByName(string name)
        {
            return CandidateDAO.Instance.SearchByName(name);
        }

        public bool UpdateCandidate(CandidateProfile candidate)
        {
            return CandidateDAO.Instance.UpdateCandidate(candidate);
        }
    }
}
