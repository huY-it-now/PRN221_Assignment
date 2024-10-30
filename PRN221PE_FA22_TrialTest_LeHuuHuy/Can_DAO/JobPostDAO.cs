using Can_BusinessObject;

namespace Can_DAO
{
    public class JobPostDAO
    {
        private CandidateManagementContext context;
        private static JobPostDAO instance;

        public JobPostDAO()
        {
            context = new CandidateManagementContext();
        }

        public static JobPostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostDAO();

                }
                return instance;
            }
        }

        public JobPosting GetId(string id)
        {
            return context.JobPostings.SingleOrDefault(m => m.PostingId.Equals(id));
        }

        public List<JobPosting> GetPostings()
        {
            return context.JobPostings.ToList();
        }

        public bool AddJobPosting(JobPosting jobPosting)

        {
            bool added = false;
            JobPosting job = GetId(jobPosting.PostingId);
            try
            {
                if (job == null)
                {
                    context.JobPostings.Add(jobPosting);
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

        public bool DeleteJobPosting(JobPosting jobPosting)

        {
            bool added = false;
            JobPosting job = GetId(jobPosting.PostingId);
            try
            {
                if (job != null)
                {
                    context.JobPostings.Remove(jobPosting);
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

        public bool UpdateJobPosting(JobPosting jobPosting)

        {
            bool added = false;
            JobPosting job = GetId(jobPosting.PostingId);
            try
            {
                if (job != null)
                {
                    job.JobPostingTitle = jobPosting.JobPostingTitle;
                    job.Description = jobPosting?.Description;
                    job.PostedDate = jobPosting?.PostedDate;

                    context.Entry<JobPosting>(job).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
    }
}
