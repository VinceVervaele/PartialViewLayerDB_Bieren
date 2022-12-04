using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PartialView.Service;
using AutoMapper;
using PartialViewLayerDB_Bieren.ViewModels;

namespace PartialViewLayerDB_Bieren.Controllers
{
    public class BierController : Controller
    {
        private readonly BierService _bierService;

        private readonly IMapper _mapper;

        public BierController(IMapper mapper)
        {// Later with DI
            _mapper = mapper;

            _bierService = new BierService();
        }
        public IActionResult Index()
        {
            var lstBier = _bierService.GetAll();  // Domain objects
            List<BierVM> bierVMs = null;

            if (lstBier != null)
            {
                bierVMs = _mapper.Map<List<BierVM>>(lstBier);
            }

            return View(bierVMs);  // Always VM 
        }
    }
}
