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
        private readonly IOfferService _personService;
        private Offer offer { get; set; }
        public List<Offer> offerList { get; set; }

        public HomeController(IOfferService personService)
        {
            _personService = personService;
        }
        public IActionResult Details(int id)
        {
            try
            {
                offer = _personService.GetOffer(id);
            }
            catch
            {
                offer = new Offer();
            }
            if(offer == null)
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
                TempData["AlertMessage"] = "Oferta o nazwie " + newOffer.name + " została dodana pomyślnie.";
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
                int pageSize = 4;
                if (page < 1)
                {
                    page = 1;
                }
                offerList = _personService.GetAllOffers();
                int offersCount = offerList.Count();
                Pager pager = new Pager(offersCount, page, pageSize);
                int pagesToSkip = (page - 1) * pageSize;
                var data = offerList.Skip(pagesToSkip).Take(pageSize).ToList();
                if(pager.TotalPages != 1)
                {
                    this.ViewBag.Pager = pager;
                }
                return View(data);
            }
            else
            {
                return RedirectToAction("Details", new { id = buttonid });
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