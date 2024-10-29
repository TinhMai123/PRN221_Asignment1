using CandidateManagement_BussinesObject;
using CandidateManagement_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepo jobPostingRepo;
        public JobPostingService()
        {
            jobPostingRepo = new JobPostingRepo();
        }

        public bool AddJobPosting(JobPosting JobPosting)
        {
            return jobPostingRepo.AddJobPosting(JobPosting);
        }

        public bool DeleteJobPosting(JobPosting JobPosting)
        {
            return jobPostingRepo.DeleteJobPosting(JobPosting);
        }

        public JobPosting? GetJobPosting(string jobId)
        {
            return jobPostingRepo.GetJobPosting(jobId);
        }

        public List<JobPosting> GetJobPostings()
        {
            return jobPostingRepo.GetJobPostings();
        }

        public bool UpdateJobPosting(JobPosting JobPosting)
        {
            return jobPostingRepo.UpdateJobPosting(JobPosting);
        }
    }
}
