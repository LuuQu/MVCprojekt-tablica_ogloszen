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
        private readonly IAdService _personService;
        private Ad Ad { get; set; }
        public List<Ad> AdList { get; set; }

        public HomeController(IAdService personService)
        {
            _personService = personService;
            
        }
        public IActionResult Details(int id)
        {
            try
            {
                Ad = _personService.GetAd(id);
            }
            catch
            {
                Ad = new Ad();
            }
            if(Ad == null)
            {
                Ad = new Ad();
            }
            return View(Ad);
        }
        [Authorize]
        public IActionResult AddAd(Ad newAd)
        {
            if (newAd.Name != null && newAd.Description != null)
            {
                TempData["AlertMessage"] = "Ogłoszenie o nazwie " + newAd.Name + " zostało dodana pomyślnie.";
                newAd.OwnerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _personService.AddAd(newAd);
                return RedirectToAction("Index");
            }
            return View(newAd);
        }
        public IActionResult Index(int page)
        {
                int pageSize = 4;
                if (page < 1)
                {
                    page = 1;
                }
                AdList = _personService.GetAllAds();
                int adCount = AdList.Count();
                Pager pager = new Pager(adCount, page, pageSize);
                int pagesToSkip = (page - 1) * pageSize;
                var data = AdList.Skip(pagesToSkip).Take(pageSize).ToList();
                if(pager.TotalPages != 1)
                {
                    this.ViewBag.Pager = pager;
                }
                return View(data);
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