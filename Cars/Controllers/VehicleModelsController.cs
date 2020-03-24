using AutoMapper;
using Cars.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Service.Data;
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
        private readonly IVehicleMakeRepository _makerepo;
        private readonly IVehicleModelRepository _modelrepo;
        private readonly IMapper _mapper;


        public VehicleModelsController(IVehicleMakeRepository makerepo, IVehicleModelRepository modelrepo, IMapper mapper)
        {
            _makerepo = makerepo;
            _modelrepo = modelrepo;
            _mapper = mapper;

        }

        // GET: VehicleModels
        [Authorize(Roles = "Administrator, Employee")]
        public async Task<IActionResult> Index(string sortOrder, string searchString)

        {
            var models = await _modelrepo.GetAll();
            var modelVMs = _mapper.Map<IEnumerable<VehicleModel>, IEnumerable<VehicleModelVM>>(models);
            
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";
            ViewData["Filter"] = searchString;

            var param = from m in modelVMs
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

        // GET: VehicleModels/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _modelrepo.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            var modelVM = _mapper.Map<VehicleModelVM>(model);
            return View(modelVM);

        }

        // GET: VehicleModels/Create
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create()
        {
            var makes = await _makerepo.GetAll();
            var makeItems = makes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.MakeId.ToString()

            }) ;

            var model = new VehicleModelVM
            {
                VehicleMakes = makeItems.ToList()
            };
            return View(model);
        }

        // POST: VehicleModels/Create
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleModelVM modelVM)
        {
            try
            {
                var makes = await _makerepo.GetAll();
                var makeItems = makes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.MakeId.ToString()

                });
                modelVM.VehicleMakes = makeItems.ToList();                

                if (!ModelState.IsValid)
                {
                    return View(modelVM);
                }

                
                var model = _mapper.Map<VehicleModel>(modelVM);
                


                await _modelrepo.Create(model);


                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(modelVM);
            }
        }

        // GET: VehicleModels/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _modelrepo.GetById(id);

            if (model == null)
            {
                return NotFound();
            }


            var modelVM = _mapper.Map<VehicleModelVM>(model);
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
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(modelVM);
                }


                var model = _mapper.Map<VehicleModel>(modelVM);
                await _modelrepo.Update(model);

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
            var model = await _modelrepo.GetById(id);

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
                
                var model = await _modelrepo.GetById(id);
                await _modelrepo.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
