using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PartialView.Service;
using PartialViewLayerDB_Bieren.ViewModels;

namespace PartialViewLayerDB_Bieren.Controllers
{
    public class BrewerController : Controller
    {
        private readonly BrewerService _brewerService;

        private readonly IMapper _mapper;

        public BrewerController(IMapper mapper)
        {// Later with DI
            _mapper = mapper;

            _brewerService = new BrewerService();
        }
        public async Task<IActionResult> Index()
        {
            var lstBrewers = await _brewerService.GetAll();  // Domain objects
            List<BrewerVM> brewerVMs = null;

            if (lstBrewers != null)
            {
                brewerVMs = _mapper.Map<List<BrewerVM>>(lstBrewers);
            }

            return View(brewerVMs);  // Always VM 
        }
    }
}
