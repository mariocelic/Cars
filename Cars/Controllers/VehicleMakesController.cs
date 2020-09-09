using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Data;
using Project.Service.Interfaces;
using Cars.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Project.Service.Helpers;

namespace Cars.Controllers
{
    [Authorize]
    public class VehicleMakesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IVehicleMakeService _vehicleMakeService;



        public VehicleMakesController(IUnitOfWork unitOfWork, IMapper mapper, IVehicleMakeService vehicleMakeService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _vehicleMakeService = vehicleMakeService;

        }

        // GET: VehicleMakes
        [Authorize(Roles = "Administrator, Employee")]
<<<<<<< HEAD
        
        public async Task<IActionResult> Index(SortingParameters sortingParameters, FilteringParameters filteringParameters, PagingParameters pagingParameters)
        {
            var SortingParams = new SortingParameters() { SortOrder = sortingParameters.SortOrder };            
            var FilteringParams = new FilteringParameters() { CurrentFilter = filteringParameters.CurrentFilter, FilterString = filteringParameters.FilterString };
            var PagingParams = new PagingParameters() { PageNumber = pagingParameters.PageNumber, PageSize = pagingParameters.PageSize };

            
            List<VehicleMake> listOfVehicleMakes = _mapper.Map<List<VehicleMake>>(await _vehicleMakeService.FindAllMakesPaged(SortingParams, FilteringParams, PagingParams));
=======
        [HttpGet(Name ="GetPaginationMakes")]
        [HttpHead]
        public async Task<IActionResult> Index([FromQuery] QueryParameters queryParameters)
        {
            var SortingParams = new SortingParameters() { SortOrder = queryParameters.SortOrder };
            var PagingParams = new PagingParameters() { PageNumber = queryParameters.PageNumber, PageSize = queryParameters.PageSize};
            var FilteringParams = new FilteringParameters() { CurrentFilter = queryParameters.CurrentFilter, FilterString = queryParameters.FilterString };

            List<VehicleMake> listOfVehicleMakes = _mapper.Map<List<VehicleMake>>(await _makeService.FindAllMakesPaged(SortingParams, FilteringParams, PagingParams));
>>>>>>> 3f6d77d7f70c248a71c9f35930ab82abd3d658c0
            if (listOfVehicleMakes == null) return BadRequest();

            return View(listOfVehicleMakes);
        }

        // GET: VehicleMakes/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int id)
        {
            var make = await _vehicleMakeService.FindVehicleMakeById(id);

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
                await _vehicleMakeService.CreateAsync(make);
                
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
            var make = await _vehicleMakeService.FindVehicleMakeById(id);

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
            var make = await _vehicleMakeService.FindVehicleMakeById(id);

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

                var make = await _vehicleMakeService.FindVehicleMakeById(id);
                await _vehicleMakeService.DeleteAsync(id);
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}