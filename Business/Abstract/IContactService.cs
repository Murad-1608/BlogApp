using Entity.Concrete;

namespace Business.Abstract
{
    public interface IContactService
    {
        void Add(Contact contact);
        List<Contact> GetAll();
        Contact Get(int id);

    }
}
