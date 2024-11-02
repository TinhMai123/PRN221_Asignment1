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
    public class DetailsModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        
        public DetailsModel(IJobPostingService jobPostings)
        {
            _jobPostingService = jobPostings;
        }

      public JobPosting JobPosting { get; set; } = default!; 

        public  IActionResult OnGet(string id)
        {
            if (id == null || _jobPostingService.GetJobPostings == null)
            {
                return NotFound();
            }

            var jobposting = _jobPostingService.GetJobPosting(id);
            if (jobposting == null)
            {
                return NotFound();
            }
            else 
            {
                JobPosting = jobposting;
            }
            return Page();
        }
    }
}
