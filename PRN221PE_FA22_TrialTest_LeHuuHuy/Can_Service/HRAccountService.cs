using Can_BusinessObject;
using Can_Repository;

namespace Can_Service
{
    public class HRAccountService : IHRAccountService
    {
        private IHRAccountRepo IHR;

        public HRAccountService()
        {
            IHR = new HRAccountRepo();
        }

        public Hraccount GetHraccountByEmail(string email)
        {
            return IHR.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHraccounts()
        {
            return IHR.GetHraccounts();
        }
    }
}
