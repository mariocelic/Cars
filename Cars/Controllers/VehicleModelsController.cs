using AutoMapper;
using Cars.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Service.Data;
using Project.Service.Helpers;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Controllers
{
    [Authorize]
    public class VehicleModelsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleMakeService _vehicleMakeService;


        public VehicleModelsController(IUnitOfWork unitOfWork, IMapper mapper, IVehicleModelService vehicleModelService, IVehicleMakeService vehicleMakeService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
        }

        // GET: VehicleModels
        [Authorize(Roles = "Administrator, Employee")]

        public async Task<IActionResult> Index(SortingParameters sortingParameters, FilteringParameters filteringParameters, PagingParameters pagingParameters)
        {
            var SortingParams = new SortingParameters() { SortOrder = sortingParameters.SortOrder };            
            var FilteringParams = new FilteringParameters() { CurrentFilter = filteringParameters.CurrentFilter, FilterString = filteringParameters.FilterString };
            var PagingParams = new PagingParameters() { PageNumber = pagingParameters.PageNumber, PageSize = pagingParameters.PageSize ?? 5 };

            ViewBag.NameSortParam = string.IsNullOrEmpty(sortingParameters.SortOrder) ? "name_desc" : "";

            List<VehicleModel> listOfVehicleModels = _mapper.Map<List<VehicleModel>>(await _vehicleModelService.FindAllModelsPaged(SortingParams, FilteringParams, PagingParams));
            if (listOfVehicleModels == null) return BadRequest();

            return View(listOfVehicleModels);


        }

        // GET: VehicleModels/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _vehicleModelService.FindVehicleModelById(id);

            if (model == null)
            {
                return NotFound();
            }

            var modelVM = _mapper.Map<VehicleModelVM>(model);
            return View(modelVM);

        }

        // GET: VehicleModels/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            var makes = _unitOfWork.VehicleMake.FindAllAsync();
            var makeItems = makes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.MakeId.ToString()

            })
            ;

            var modelVM = new VehicleModelVM
            {

                VehicleMakeList = makeItems.ToList().OrderBy(m=>m.Text)
            };

            return View(modelVM);
        }

        // POST: VehicleModels/Create
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleModelVM modelVM)
        {
            try
            {
                var makes = _unitOfWork.VehicleMake.FindAllAsync();

                var makeItems = makes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.MakeId.ToString()

                });

                modelVM.VehicleMakeList = makeItems.ToList();


                if (!ModelState.IsValid)
                {
                    return View(modelVM);
                }

                
                var model = _mapper.Map<VehicleModelVM>(modelVM);
                
                var carModel = _mapper.Map<VehicleModel>(model);
                await _vehicleModelService.CreateAsync(carModel);
                
                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                return View(modelVM);
            }
        }

        // GET: VehicleModels/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _vehicleModelService.FindVehicleModelById(id);

            if (model == null)
            {
                return NotFound();
            }

            var makes = _unitOfWork.VehicleMake.FindAllAsync();
            var makeItems = makes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.MakeId.ToString()

            })
            ;

            var newModel = new VehicleModelVM
            {
                ModelId = model.ModelId,
                Name = model.Name,
                Abrv = model.Abrv,
                MakeId = model.MakeId,
                VehicleMakeList = makeItems.ToList().OrderBy(m => m.Text)
            };


            var modelVM = _mapper.Map<VehicleModelVM>(newModel);

            return View(modelVM);


        }

        // POST: VehicleModels/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VehicleModelVM modelVM)
        {
            try
            {
                var makes = _unitOfWork.VehicleMake.FindAllAsync();

                var makeItems = makes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.MakeId.ToString()

                });

                modelVM.VehicleMakeList = makeItems.ToList();


                if (!ModelState.IsValid)
                {
                    return View(modelVM);
                }
                
                
                var model = _mapper.Map<VehicleModel>(modelVM);
                

                _unitOfWork.VehicleModel.Update(model);
                await _unitOfWork.CommitAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(modelVM);
            }
        }


        // GET: VehicleModels/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _vehicleModelService.FindVehicleModelById(id);

            if (model == null)
            {
                return NotFound();
            }


            var modelVM = _mapper.Map<VehicleModelVM>(model);
            return View(modelVM);
        }

        // POST: VehicleModels/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                
                var model = await _vehicleModelService.FindVehicleModelById(id);
                await _vehicleModelService.DeleteAsync(id);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
