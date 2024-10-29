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

namespace CandidateManagement_MaiVanQuocTinh.Pages.Tinh
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileService _profileService;
        private readonly IJobPostingService _postingService;


        public CreateModel(ICandidateProfileService candidate, IJobPostingService jobPosting)
        {
            _profileService = candidate;
            _postingService = jobPosting;
        }

        public IActionResult OnGet()
        {
        ViewData["PostingId"] = new SelectList(_postingService.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          if (!ModelState.IsValid || _profileService.GetCandidateProfiles() == null || CandidateProfile == null)
            {
                return Page();
            }

            _profileService.AddCandidateProfile(CandidateProfile);

            return RedirectToPage("./Index");
        }
    }
}
