using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BussinesObject;
using CandidateManagement_DAO;
using CandidateManagement_Service;

namespace CandidateManagement_MaiVanQuocTinh.Pages.JobPostingPage
{
    public class EditModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;


        public EditModel(IJobPostingService jobPostings)
        {
            _jobPostingService = jobPostings;
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;

        public IActionResult OnGet(string id)
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
            JobPosting = jobposting;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _jobPostingService?.UpdateJobPosting(JobPosting);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPostingExists(JobPosting.PostingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobPostingExists(string id)
        {
            return _jobPostingService.GetJobPosting(id) != null;
        }
    }

}
