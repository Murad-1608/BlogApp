using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            categoryDal.Add(category);
        }

        public void Delete(int id)
        {
            var category = categoryDal.Get(x => x.Id == id);

            categoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return categoryDal.GetAll(x => x.Status == true);
        }
    }
}
