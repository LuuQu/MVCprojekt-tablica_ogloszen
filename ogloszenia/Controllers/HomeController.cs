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
            //_personService - zbiór wszystkich Interfejsy/Serwisy użytych w programie
            _personService = personService;
        }
        public IActionResult Details()
        {
            int id = 0;
            //Próba wczytania z serwisów id oferty, której chcemy wyświetlić szczegóły
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
                //w razie braku możliwości wczytania oferty, wyświetla domyślną stronę bez danych
                offer = new Offer();
            }
            return View(offer);
        }
        [Authorize]
        public IActionResult AddOffer(Offer newOffer)
        {
            //Program wchodzi w if-a jeżeli dane na stronie zostały poprawnie wypełnione
            if (newOffer.name != null && newOffer.description != null)
            {
                //Tworzenie potwierdzenia poprawnego dodania oferty
                TempData["AlertMessage"] = "Oferta o nazwie " + newOffer.name + " została dodana pomyślnie.";
                //Dodawanie oferty i powrót do Indexa
                newOffer.ownerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _personService.AddOffer(newOffer);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Index(int buttonid, int page)
        {
            if (buttonid == 0)
            {
                //Tworzenie komponentów potrzebnych do page-owania
                int pageSize = 4;
                if (page < 1)
                {
                    page = 1;
                }
                //Wczyt ofert
                offerList = _personService.GetAllOffers();
                int offersCount = offerList.Count();
                Pager pager = new Pager(offersCount, page, pageSize);
                //pagesToSkip - ilość ofert, które są wyświetlane na poprzednich stronach
                int pagesToSkip = (page - 1) * pageSize;
                var data = offerList.Skip(pagesToSkip).Take(pageSize).ToList();
                if(pager.TotalPages != 1)
                {
                    //Pasek do page'owania jest tworzony, gdy jest więcej, niż 1 strona
                    this.ViewBag.Pager = pager;
                }
                return View(data);
            }
            //Wykonuje się przy kliknięciu na wybraną ofertę
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