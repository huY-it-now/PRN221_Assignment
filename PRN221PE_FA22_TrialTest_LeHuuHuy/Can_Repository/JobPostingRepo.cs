using Can_BusinessObject;
using Can_DAO;

namespace Can_Repository
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public bool AddJobPosting(JobPosting jobPosting)
        {
            return JobPostDAO.Instance.AddJobPosting(jobPosting);
        }

        public bool DeleteJobPosting(JobPosting jobPosting)
        {
            return JobPostDAO.Instance.DeleteJobPosting(jobPosting);
        }

        public JobPosting GetId(string id)
        {
            return JobPostDAO.Instance.GetId(id);
        }

        public List<JobPosting> GetPostings()
        {
            return JobPostDAO.Instance.GetPostings();
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return JobPostDAO.Instance.UpdateJobPosting(jobPosting);
        }
    }
}
