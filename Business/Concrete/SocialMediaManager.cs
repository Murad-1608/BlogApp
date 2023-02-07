using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using static System.Net.WebRequestMethods;

namespace Business.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal socialMediaDal;
        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            this.socialMediaDal = socialMediaDal;
        }

        public SocialMedia Get()
        {
            return socialMediaDal.GetAll().Last();
        }

        public void Update(SocialMedia socialMedia)
        {
            socialMediaDal.Update(socialMedia);
        }

        public void Add(SocialMedia socialMedia)
        {
            socialMediaDal.Add(socialMedia);
        }
    }
}
