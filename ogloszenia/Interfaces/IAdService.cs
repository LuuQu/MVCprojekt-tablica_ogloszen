using ogloszenia.Models;

namespace ogloszenia.Interfaces
{
    public interface IAdService
    {
        public List<Ad> GetAllAds();
        public void AddAd(Ad offer);
        public Ad GetAd(int? id);
    }
}
