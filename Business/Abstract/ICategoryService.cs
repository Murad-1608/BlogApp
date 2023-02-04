using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        void Add(Category category);
        void Delete(int id);
    }
}
