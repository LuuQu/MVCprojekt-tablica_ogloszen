using Microsoft.AspNetCore.Mvc;
using ogloszenia.Models;
using ogloszenia.Interfaces;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ogloszenia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOfferService _personService;
        private Offer offer { get; set; }
        public List<Offer> offerList { get; set; }

        public HomeController(ILogger<HomeController> logger, IOfferService personService)
        {
            _logger = logger;
            _personService = personService;
            offerList = _personService.GetAllOffers();
        }
        public IActionResult Details()
        {
            int id = 0;
            try
            {
                id = int.Parse(HttpContext.Session.GetString("id"));
            }
            catch 
            {
            }
            if(id != 0)
            {
                offer = _personService.GetOffer(id);
            }
            else
            {
                offer = new Offer();
            }
            return View(offer);
        }
        [Authorize]
        public IActionResult AddOffer(Offer newOffer)
        {
            if (newOffer.name != null && newOffer.description != null)
            {
                newOffer.ownerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _personService.AddOffer(newOffer);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Index(int buttonid)
        {
            if(buttonid == 0)
            {
                return View(offerList);
            }
            else
            {
                HttpContext.Session.SetString("id", buttonid.ToString());
                return RedirectToAction("Details");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}