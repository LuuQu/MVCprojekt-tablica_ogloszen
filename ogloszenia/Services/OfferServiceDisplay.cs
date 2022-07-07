using ogloszenia.Data;
using ogloszenia.Interfaces;
using ogloszenia.Models;

namespace ogloszenia.Services
{
    public class OfferServiceDisplay: IOfferService
    {
        private readonly ApplicationDbContext _context;
        public OfferServiceDisplay(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Offer> GetAllOffers()
        {
            return _context.Offer;
        }
        public void AddOffer(Offer offer)
        {
            _context.Offer.Add(offer);
            _context.SaveChanges();
        }
        public Offer GetOffer(int? id)
        {
            return _context.Offer.FirstOrDefault(m => m.id == id);
        }
    }
}
