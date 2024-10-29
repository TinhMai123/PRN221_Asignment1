using CandidateManagement_BussinesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_DAO
{
    public class HRAccountDAO
    {
        private CandidateManagementContext _context;
        private static HRAccountDAO? instance = null;

        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }
        public HRAccountDAO()
        {
            _context = new CandidateManagementContext();
        }

        public Hraccount? GetHraccountByEmail(string email)
        {
            return _context.Hraccounts.SingleOrDefault(x => x.Email.Equals(email));
        }

        public List<Hraccount> GetHraccounts()
        {
            return _context.Hraccounts.ToList();
        }

    }
}
