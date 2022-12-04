using Microsoft.AspNetCore.Mvc;
using PartialView.Service;
using PartialViewLayerDB_Bieren.ViewModels;

namespace PartialViewLayerDB_Bieren.Controllers
{
    public class BierController : Controller
    {
        private readonly BierService _bierService;

        public BierController()
        {// Later with DI
            _bierService = new BierService();
        }
        public IActionResult Index()
        {
            var lstBier = _bierService.GetAll();  // Domain objects
            List<BierVM> bierVMs = new List<BierVM>();

            if (lstBier != null)
            {
                foreach (var bier in lstBier)
                {
                    var bierVM = new BierVM();
                    // later we use an automapper
                    bierVM.Naam = bier.Naam;
                    bierVM.Brouwernaam = bier.BrouwernrNavigation.Naam;
                    bierVM.Soortnaam = bier.SoortnrNavigation.Soortnaam;
                    bierVM.Alchohol = bier.Alcohol;
                    bierVM.Image = bier.Image;
                   
                    bierVMs.Add(bierVM);
                }
            }

            return View(bierVMs);  // Always VM 
        }
    }
}
