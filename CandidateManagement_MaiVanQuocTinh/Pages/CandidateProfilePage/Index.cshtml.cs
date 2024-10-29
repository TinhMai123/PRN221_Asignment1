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
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;

        public IndexModel(ICandidateProfileService candidate)
        {
            _candidateProfileService = candidate;
        }

        public IList<CandidateProfile> CandidateProfile { get;set; } = default!;

        public void OnGet()
        {
            if (_candidateProfileService.GetCandidateProfiles() != null)
            {
                CandidateProfile =  _candidateProfileService.GetCandidateProfiles();
            }
        }
    }
}
