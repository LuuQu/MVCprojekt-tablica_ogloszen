using ogloszenia.Data;
using ogloszenia.Interfaces;
using ogloszenia.Models;

namespace ogloszenia.Services
{
    public class AdService: IAdService
    {
        private readonly ApplicationDbContext _context;
        public AdService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Ad> GetAllAds()
        { 
            return _context.Ad.OrderByDescending(x => x.date).Where(x => x.date > DateTime.Now.AddDays(-10)).ToList();
        }
        public void AddAd(Ad Ad)
        {
            Ad.date = DateTime.Now;
            _context.Ad.Add(Ad);
            _context.SaveChanges();
        }
        public Ad GetAd(int? id)
        {
            return _context.Ad.FirstOrDefault(m => m.id == id);
        }
    }
}
