using Can_BusinessObject;

namespace Can_Service
{
    public interface IJobPostingService
    {
        public JobPosting GetId(string id);
        public List<JobPosting> GetPostings();
        public bool AddJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(JobPosting jobPosting);
        public bool UpdateJobPosting(JobPosting jobPosting);
    }
}
