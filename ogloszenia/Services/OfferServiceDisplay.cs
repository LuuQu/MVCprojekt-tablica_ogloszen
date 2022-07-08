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
        public List<Offer> GetAllOffers()
        { 
            return _context.Offer.OrderByDescending(x => x.date).Where(x => x.date > DateTime.Now.AddDays(-10)).ToList();
        }
        public void AddOffer(Offer offer)
        {
            offer.date = DateTime.Now;
            _context.Offer.Add(offer);
            _context.SaveChanges();
        }
        public Offer GetOffer(int? id)
        {
            return _context.Offer.FirstOrDefault(m => m.id == id);
        }
    }
}
