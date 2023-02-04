using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            this.aboutDal = aboutDal;
        }

        public About GetLastAbout()
        {
            return aboutDal.GetAll().Last();
        }
    }
}
