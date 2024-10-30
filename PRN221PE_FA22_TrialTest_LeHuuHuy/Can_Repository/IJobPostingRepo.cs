using Can_BusinessObject;

namespace Can_Repository
{
    public interface IJobPostingRepo
    {
        public JobPosting GetId(string id);
        public List<JobPosting> GetPostings();
        public bool AddJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(JobPosting jobPosting);
        public bool UpdateJobPosting(JobPosting jobPosting);
    }
}
