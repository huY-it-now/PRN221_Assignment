using Can_BusinessObject;
using System.Security.Principal;

namespace Can_DAO
{
    public class HRAccountDAO
    {
        private CandidateManagementContext context;
        private static HRAccountDAO instance;

        public HRAccountDAO()
        {
            context = new CandidateManagementContext();
        }

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

        public Hraccount GetHraccountByEmail(string email)
        {
            return context.Hraccounts.SingleOrDefault(x => x.Email == email);
        }

        public List<Hraccount> GetHraccounts()
        {
            return context.Hraccounts.ToList();
        }
    }
}
