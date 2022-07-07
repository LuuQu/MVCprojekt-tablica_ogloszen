using ogloszenia.Models;

namespace ogloszenia.Interfaces
{
    public interface IOfferService
    {
        public List<Offer> GetAllOffers();
        public void AddOffer(Offer offer);
        public Offer GetOffer(int? id);
    }
}
