using CandidateManagement_BussinesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service
{
    public interface ICandidateProfileService
    {
        public CandidateProfile? GetCandidateProfileById(string id);


        public List<CandidateProfile> GetCandidateProfiles();

        public bool AddCandidateProfile(CandidateProfile candidateProfile);

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile);

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile);
    }
}
