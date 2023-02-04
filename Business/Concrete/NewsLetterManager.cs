using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterDal newsLetterDal;
        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            this.newsLetterDal = newsLetterDal;
        }

        public void Add(NewsLetter newsLetter)
        {
            newsLetterDal.Add(newsLetter);
        }
    }
}
