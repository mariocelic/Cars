using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Data;
using Project.Service.Interfaces;
using Cars.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Cars.Controllers
{
    [Authorize]
    public class VehicleMakesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IVehicleMakeService _makeService;



        public VehicleMakesController(IUnitOfWork unitOfWork, IMapper mapper, IVehicleMakeService makeService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _makeService = makeService;

        }

        // GET: VehicleMakes
        [Authorize(Roles = "Administrator, Employee")]
        public async Task<IActionResult> Index()
        {            
            var makes = _mapper.Map<IEnumerable<VehicleMakeVM>>(await _makeService.FindAllMakesPagedAsync());
            if (makes == null) return BadRequest();

            return View(makes);

        }

        // GET: VehicleMakes/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int id)
        {
            var make = await _unitOfWork.VehicleMake.GetById(id);

            if (make == null)
            {
                return NotFound();
            }

            var makeVM = _mapper.Map<VehicleMakeVM>(make);
            return View(makeVM);

        }

        // GET: VehicleMakes/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        [Authorize(Roles = "Administrator")]
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
                await _unitOfWork.VehicleMake.Create(make);
                await _unitOfWork.CommitAsync();


                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(makeVM);
            }
        }

        // GET: VehicleMakes/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var make = await _unitOfWork.VehicleMake.GetById(id);

            if (make == null)
            {
                return NotFound();
            }


            var makeVM = _mapper.Map<VehicleMakeVM>(make);
            return View(makeVM);
        }

        // POST: VehicleMakes/Edit/5
        [Authorize(Roles = "Administrator")]
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


                var makeItem = _mapper.Map<VehicleMake>(makeVM);
                _unitOfWork.VehicleMake.Update(makeItem);
                await _unitOfWork.CommitAsync();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(makeVM);
            }
        }

        // GET: VehicleMakes/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var make = await _unitOfWork.VehicleMake.GetById(id);

            if (make == null)
            {
                return NotFound();
            }


            var makeVM = _mapper.Map<VehicleMakeVM>(make);
            return View(makeVM);
        }

        // POST: VehicleMakes/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {

                var make = await _unitOfWork.VehicleMake.GetById(id);
                await _unitOfWork.VehicleMake.Delete(id);
                await _unitOfWork.CommitAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}