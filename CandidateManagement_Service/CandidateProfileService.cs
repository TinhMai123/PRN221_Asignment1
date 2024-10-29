using CandidateManagement_BussinesObject;
using CandidateManagement_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private ICandidateProfileRepo profileRepo;

        public CandidateProfileService()
        {
           profileRepo = new CandidateProfileRepo();
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.AddCandidateProfile(candidateProfile);
        }

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.DeleteCandidateProfile(candidateProfile);
        }

        public CandidateProfile? GetCandidateProfileById(string id)
        {
            return profileRepo.GetCandidateProfileById(id);
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return profileRepo.GetCandidateProfiles();
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.UpdateCandidateProfile(candidateProfile);
        }
    }
}
