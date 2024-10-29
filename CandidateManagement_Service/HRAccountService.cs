using CandidateManagement_BussinesObject;
using CandidateManagement_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service
{
    public class HRAccountService : IHRAccountService
    {
        private IHRAccountRepo IAccRepo;

        
        public HRAccountService() {
            IAccRepo = new HRAccountRepo();
        }
        public Hraccount? GetHraccountByEmail(string email)
        {
            return IAccRepo.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHraccounts()
        {
            return IAccRepo.GetHraccounts();
        }
    }
}
