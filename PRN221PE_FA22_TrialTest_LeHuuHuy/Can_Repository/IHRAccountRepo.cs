using Can_BusinessObject;

namespace Can_Repository
{
    public interface IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email);
        public List<Hraccount> GetHraccounts();
    }
}
