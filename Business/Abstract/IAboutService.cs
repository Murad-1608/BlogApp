using Entity.Concrete;

namespace Business.Abstract
{
    public interface IAboutService
    {
        About GetLastAbout();
        void Update(About about);
    }
}
