using CandidateManagement_BussinesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CandidateManagement_DAO
{
    public class JobPostingDAO
    {
        private CandidateManagementContext _context;
        private static JobPostingDAO? instance;

        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }

        public JobPostingDAO()
        {
            _context = new CandidateManagementContext();
        }
        public JobPosting? GetJobPosting(string jobId)
        {
            return _context.JobPostings.SingleOrDefault(x => x.PostingId == jobId);
        }
        public List<JobPosting> GetJobPostings()
        {
            return _context.JobPostings.ToList();
        }

        public bool AddJobPosting(JobPosting JobPosting)
        {
            bool isSuccess = false;
            JobPosting? jobPosting = this.GetJobPosting(JobPosting.PostingId);
            try
            {
                if (jobPosting == null)
                {
                    _context.JobPostings.Add(JobPosting);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool DeleteJobPosting(JobPosting JobPosting)
        {
            bool isSuccess = false;
            JobPosting? jobPosting = this.GetJobPosting(JobPosting.PostingId);
            try
            {
                if (jobPosting != null)
                {
                    _context.JobPostings.Remove(jobPosting);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool UpdateJobPosting(JobPosting update)
        {
            bool isSuccess = false;
            JobPosting? jobPosting = GetJobPosting(update.PostingId);
            try
            {
                if (jobPosting != null)
                {
                    _context.Entry<JobPosting>(update).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    _context.Entry<JobPosting>(update).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    isSuccess = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isSuccess;
        }

    }
}
