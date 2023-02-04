using Business.Abstract;
using Business.Helper;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            this.blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            blogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            SystemIOOperations.DeletePhoto("Blog", blog.Image);
            blogDal.Delete(blog);
        }

        public List<Blog> GetBlogListByWriter(int writerId)
        {
            return blogDal.GetAll(x => x.AppUserId == writerId && x.Status == true);
        }

        public Blog GetById(int id)
        {
            return blogDal.Get(x => x.Id == id);
        }

        public List<Blog> GetListWithCategory()
        {
            return blogDal.GetListWithCategory();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return blogDal.GetListWithCategory(x => x.Status == true && x.AppUserId == id);
        }

        public List<Blog> Last3Blogs()
        {
            return blogDal.GetAll(x => x.Status == true).TakeLast(3).ToList();
        }

        public Blog LastestBlog()
        {
            return blogDal.GetAll(x => x.Status == true).Last();
        }

        public void Update(Blog blog)
        {
            blogDal.Update(blog);
        }
    }
}
