using Can_BusinessObject;
using Can_DAO;

namespace Can_Repository
{
    public class HRAccountRepo : IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email)
        {
            return HRAccountDAO.Instance.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHraccounts()
        {
            return HRAccountDAO.Instance.GetHraccounts();
        }
    }
}
