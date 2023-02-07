using Entity.Concrete;

namespace Business.Abstract
{
    public interface ISocialMediaService
    {
        SocialMedia Get();

        void Update(SocialMedia socialMedia);
    }
}
