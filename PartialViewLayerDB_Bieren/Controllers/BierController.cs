using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PartialView.Service;
using AutoMapper;
using PartialViewLayerDB_Bieren.ViewModels;
using PartialView.Models.Entities;
using System.Collections;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PartialViewLayerDB_Bieren.Controllers
{
    public class BierController : Controller
    {
        private readonly BierService _bierService;
        private readonly BrewerService _breweryService;

        private readonly IMapper _mapper;

        public BierController(IMapper mapper)
        {// Later with DI
            _mapper = mapper;

            _bierService = new BierService();

            _breweryService = new BrewerService();
        }
        public async Task<IActionResult> Index()
        {
            var lstBier = await _bierService.GetAll();  // Domain objects
            List<BierVM> bierVMs = null;

            if (lstBier != null)
            {
                bierVMs = _mapper.Map<List<BierVM>>(lstBier);
            }

            return View(bierVMs);  // Always VM 
        }

        public IActionResult GetBeersByAlcohol()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetBeersByAlcohol(int? txtAlcohol)
        {
            if(txtAlcohol == null)
            {
                return GetBeersByAlcohol();
            }

            var lstBier = await _bierService.GetAlcohol((decimal)txtAlcohol);


            List<BierVM> bierVMs = null;

            if(lstBier != null)
            {
                bierVMs = _mapper.Map<List<BierVM>>(lstBier);
            }
            

            return View(bierVMs);
        }

        public async Task<IActionResult> GetBrouwer()
        {
            ViewBag.lstBrouwer = new SelectList(await _breweryService.GetAll(), "Naam", "Naam");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetBrouwer(String brouwerId)
        {
            var lstBier = await _bierService.GetBeerWithBrewer(brouwerId);

            ViewBag.lstBrouwer = new SelectList(await _breweryService.GetAll(), "Naam", "Naam");

            ViewBag.Naam = brouwerId;

            List<BierVM> bierVMs = null;

            if (lstBier != null)
            {
                bierVMs = _mapper.Map<List<BierVM>>(lstBier);
            }


            return View(bierVMs);
        }
    }
}
