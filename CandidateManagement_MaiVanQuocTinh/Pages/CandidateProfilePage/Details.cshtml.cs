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

namespace CandidateManagement_MaiVanQuocTinh.Pages.Tinh
{
    public class DetailsModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;

        public DetailsModel(ICandidateProfileService candidate)
        {
            _candidateProfileService = candidate;
        }

      public CandidateProfile CandidateProfile { get; set; } = default!; 

        public IActionResult OnGet(string id)
        {
            if (id == null || _candidateProfileService.GetCandidateProfiles() == null)
            {
                return NotFound();
            }

            var candidateprofile =  _candidateProfileService.GetCandidateProfileById(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            else 
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }
    }
}
