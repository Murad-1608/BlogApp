using Entity.Concrete;

namespace Business.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByWriter(int id);
        Blog GetById(int id);
        List<Blog> GetBlogListByWriter(int writerId);

        void Update(Blog blog);
        Blog LastestBlog();
        List<Blog> Last3Blogs();
        void Delete(Blog blog);    
        void Add(Blog blog);    
    }
}
