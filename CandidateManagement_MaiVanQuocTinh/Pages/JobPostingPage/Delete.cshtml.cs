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
using SQLitePCL;

namespace CandidateManagement_MaiVanQuocTinh.Pages.JobPostingPage
{
    public class DeleteModel : PageModel
    {
        private readonly IJobPostingService _postingService;


        public DeleteModel(IJobPostingService jobPostings)
        {
            _postingService = jobPostings;
        }

        [BindProperty]
      public JobPosting JobPosting { get; set; } = default!;

        public IActionResult OnGet(string id)
        {
            if (id == null || _postingService.GetJobPostings == null)
            {
                return NotFound();
            }

            var jobposting =  _postingService.GetJobPosting(id);

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

        public  IActionResult OnPost(string id)
        {
            if (id == null || _postingService.GetJobPostings == null)
            {
                return NotFound();
            }
            var jobposting = _postingService.GetJobPosting(id);

            if (jobposting != null)
            {
                JobPosting = jobposting;
                _postingService.DeleteJobPosting(jobposting);
            }

            return RedirectToPage("./Index");
        }
    }
}
