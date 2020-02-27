using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Data;
using Project.Service.Interfaces;
using Cars.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cars.Controllers
{
    public class VehicleMakesController : Controller
    {
        private readonly IVehicleMakeRepository _repo;
        private readonly IMapper _mapper;

        public VehicleMakesController(IVehicleMakeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        // GET: VehicleMakes
        public async Task<IActionResult> Index()
                   
        {
            var makes = await _repo.GetAll();                         
                                   
            var makeVMs = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeVM>>(makes);

            return View(makeVMs);
            
        }

        // GET: VehicleMakes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var make = await _repo.GetById(id);

            if (make == null)
            {
                return NotFound();
            }

            var makeVM = _mapper.Map<VehicleMakeVM>(make);
            return View(makeVM);

        }

        // GET: VehicleMakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleMakeVM makeVM)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(makeVM);
                }

                var make = _mapper.Map<VehicleMake>(makeVM);
                await _repo.Create(make);
                                
                
                return RedirectToAction(nameof(Index));                                     

            }
            catch
            {
                return View(makeVM);
            }
        }

        // GET: VehicleMakes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var make = await _repo.GetById(id);

            if (make == null)
            {
                return NotFound();
            }

            
            var makeVM = _mapper.Map<VehicleMakeVM>(make);
            return View(makeVM);
        }

        // POST: VehicleMakes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VehicleMakeVM makeVM)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(makeVM);
                }
                

                var make = _mapper.Map<VehicleMake>(makeVM);               
                await _repo.Update(make);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(makeVM);
            }
        }

        // GET: VehicleMakes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}