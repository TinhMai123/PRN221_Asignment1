using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagement_BussinesObject;
using CandidateManagement_DAO;
using CandidateManagement_Service;

namespace CandidateManagement_MaiVanQuocTinh.Pages.JobPostingPage
{
    public class CreateModel : PageModel
    {
        private readonly IJobPostingService _postingService;


        public CreateModel(IJobPostingService jobPostings)
        {
            _postingService = jobPostings;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          if (!ModelState.IsValid || _postingService.GetJobPostings == null || JobPosting == null)
            {
                return Page();
            }
            _postingService.AddJobPosting(JobPosting);
             
            return RedirectToPage("./Index");
        }
    }
}
