using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Data;
using Project.Service.Interfaces;
using Cars.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

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
        public async Task<IActionResult> Index(string sortOrder, string searchString)
                   
        {
            var makes = await _repo.GetAll();                         
                                   
            var makeVMs = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeVM>>(makes);

            
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";
            ViewData["Filter"] = searchString;

            var param = from m in makeVMs 
                       select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                param = param.Where(p => p.Name.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "nameDesc":
                    param = param.OrderByDescending(m => m.Name);
                    break;
                default:
                    param = param.OrderBy(m => m.Name);
                    break;
            }


           
            return View(param);

            
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
        public async Task<IActionResult> Delete(int id)
        {
            var make = await _repo.GetById(id);

            if (make == null)
            {
                return NotFound();
            }


            var makeVM = _mapper.Map<VehicleMakeVM>(make);
            return View(makeVM);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here

                var make = await _repo.GetById(id);
                await _repo.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}