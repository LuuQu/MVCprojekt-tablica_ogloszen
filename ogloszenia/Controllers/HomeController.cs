using Microsoft.AspNetCore.Mvc;
using ogloszenia.Models;
using ogloszenia.Interfaces;
using System.Diagnostics;

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
            return View();
        }
        public IActionResult Index()
        {

            return View(offerList);
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