using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BussinesObject;
using CandidateManagement_DAO;
using CandidateManagement_Service;

namespace CandidateManagement_MaiVanQuocTinh.Pages.JobPostingPage
{
    public class IndexModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;


        public IndexModel(IJobPostingService jobPosting)
        {
            _jobPostingService = jobPosting;
        }

        public IList<JobPosting> JobPosting { get;set; } = default!;

        public void OnGet()
        {
            if (_jobPostingService.GetJobPostings != null)
            {
                JobPosting = _jobPostingService.GetJobPostings();
            }
        }
    }
}
