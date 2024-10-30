using Can_BusinessObject;

namespace Can_DAO
{
    public class CandidateDAO
    {
        private CandidateManagementContext context;
        private static CandidateDAO instance;

        public CandidateDAO()
        {
            context = new CandidateManagementContext();
        }

        public static CandidateDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateDAO();

                }
                return instance;
            }
        }

        public CandidateProfile GetId(string id)
        {
            return context.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }

        public List<CandidateProfile> GetCandidates()
        {
            return context.CandidateProfiles.ToList();
        }

        public bool AddCandidateProfile(CandidateProfile candidate)

        {
            bool added = false;
            CandidateProfile can = GetId(candidate.CandidateId);
            try
            {
                if (can == null)
                {
                    context.CandidateProfiles.Add(candidate);
                    context.SaveChanges();
                    added = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return added;
        }

        public bool DeleteCandidate(CandidateProfile candidate)

        {
            bool added = false;
            CandidateProfile can = GetId(candidate.CandidateId);
            try
            {
                if (can != null)
                {
                    context.CandidateProfiles.Remove(candidate);
                    context.SaveChanges();
                    added = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return added;
        }

        public bool UpdateCandidate(CandidateProfile candidate)

        {
            bool added = false;
            CandidateProfile can = GetId(candidate.CandidateId);
            try
            {
                if (can != null)
                {
                    can.Fullname = candidate.Fullname;
                    can.ProfileUrl = candidate?.ProfileUrl;
                    can.Birthday = candidate?.Birthday;
                    can.ProfileShortDescription = candidate?.ProfileShortDescription;
                    can.PostingId = candidate?.PostingId;

                    context.Entry<CandidateProfile>(can).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    added = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return added;
        }

        public List<CandidateProfile> SearchByName(string name)
        {
            return context.CandidateProfiles.Where(a => a.Fullname.Contains(name)).ToList();
        }
    }
}
