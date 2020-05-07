using AutoMapper;
using Cars.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Service.Data;
using Project.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Controllers
{
    [Authorize]
    public class VehicleModelsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public VehicleModelsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;           
            _mapper = mapper;            
        }

        // GET: VehicleModels
        [Authorize(Roles = "Administrator, Employee")]
        public async Task<IActionResult> Index()

        {
            var models = await _unitOfWork.VehicleModel.GetAllWithMake();
            var modelVMs = _mapper.Map<IEnumerable<VehicleModel>, IEnumerable<VehicleModelVM>>(models);
            
            return View(modelVMs);


        }

        // GET: VehicleModels/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _unitOfWork.VehicleModel.GetByIdWithMake(id);

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
            var makes = await _unitOfWork.VehicleMake.GetAll();
            var makeItems = makes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.MakeId.ToString()

            })
            ;

            var modelVM = new VehicleModelVM
            {
                VehicleMakeList = makeItems.ToList()
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
                var makes = await _unitOfWork.VehicleMake.GetAll();
                
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

                var newModel = new VehicleModelVM
                {
                    ModelId = modelVM.ModelId,
                    Name = modelVM.Name,
                    Abrv = modelVM.Abrv,
                    MakeId = modelVM.MakeId,
                    VehicleMakeList = modelVM.VehicleMakeList
                };
               
                var carModel =_mapper.Map<VehicleModel>(newModel);

                await _unitOfWork.VehicleModel.Create(carModel);
                await _unitOfWork.Commit();


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
            var makes = await _unitOfWork.VehicleMake.GetAll();
            var makeItems = makes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.MakeId.ToString()

            })
            ;

            var modelVM = new VehicleModelVM
            {
                VehicleMakeList = makeItems.ToList()
            };

            var model = await _unitOfWork.VehicleModel.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            var newModelVM = _mapper.Map<VehicleModelVM>(model);
            return View(newModelVM);
            
            
        }

        // POST: VehicleModels/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VehicleModelVM modelVM)
        {
            try
            {
                var makes = await _unitOfWork.VehicleModel.GetAllWithMake();

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

                var newModel = new VehicleModelVM
                {
                    ModelId = modelVM.ModelId,
                    Name = modelVM.Name,
                    Abrv = modelVM.Abrv,
                    MakeId = modelVM.MakeId,
                    VehicleMakeList = modelVM.VehicleMakeList
                };
                var model = _mapper.Map<VehicleModel>(newModel);
                await _unitOfWork.VehicleModel.Update(model);
                await _unitOfWork.Commit();

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
            var model = await _unitOfWork.VehicleModel.GetByIdWithMake(id);

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
                
                var model = await _unitOfWork.VehicleModel.GetByIdWithMake(id);
                await _unitOfWork.VehicleModel.Delete(id);
                await _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
