using CandidateManagement_BussinesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service
{
    public  interface IHRAccountService
    {
        public Hraccount? GetHraccountByEmail(string email);
        public List<Hraccount> GetHraccounts();
    }
}
