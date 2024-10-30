using Can_BusinessObject;

namespace Can_Service
{
    public interface IHRAccountService
    {
        public Hraccount GetHraccountByEmail(string email);
        public List<Hraccount> GetHraccounts();
    }
}
