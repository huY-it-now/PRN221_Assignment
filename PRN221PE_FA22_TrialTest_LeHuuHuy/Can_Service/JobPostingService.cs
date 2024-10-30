using Can_BusinessObject;
using Can_Repository;

namespace Can_Service
{
    public class JobPostingService : IJobPostingService
    {
        private IJobPostingRepo IJP;

        public JobPostingService()
        {
            IJP = new JobPostingRepo();
        }

        public bool AddJobPosting(JobPosting jobPosting)
        {
            return IJP.AddJobPosting(jobPosting);
        }

        public bool DeleteJobPosting(JobPosting jobPosting)
        {
            return IJP.DeleteJobPosting(jobPosting);
        }

        public JobPosting GetId(string id)
        {
            return IJP.GetId(id);
        }

        public List<JobPosting> GetPostings()
        {
            return IJP.GetPostings();
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return IJP.UpdateJobPosting(jobPosting);
        }
    }
}
