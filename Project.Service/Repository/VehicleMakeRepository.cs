<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using Project.Service.Data;
=======
﻿using AutoMapper;
using Project.Service.Data;
using Project.Service.Helpers;
>>>>>>> 3f6d77d7f70c248a71c9f35930ab82abd3d658c0
using Project.Service.Interfaces;
using System.Linq;

namespace Project.Service.Repository
{
    public class VehicleMakeRepository : AsyncRepositoryBase<VehicleMake>, IVehicleMakeRepository
    {
        private readonly ApplicationDbContext _context;
<<<<<<< HEAD
=======
        private readonly IMapper _mapper;

>>>>>>> 3f6d77d7f70c248a71c9f35930ab82abd3d658c0


        public VehicleMakeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
<<<<<<< HEAD

        }

        public IQueryable<VehicleMake> FindAllAsync()
        {
            return _context.VehicleMakes.AsNoTracking();
        }
    }    
=======
            _mapper = mapper;

        }

        public async Task<IList<VehicleMake>> FindAllMakesPaged(ISortingParameters sortingParams, IFilteringParameters filteringParams, IPagingParameters pagingParams)
        {
            IQueryable<VehicleMake> vehicleMakes;

            // Filtering
            using (_context)
            {
                try
                {

                    if (filteringParams.FilterString != null)
                    {
                        pagingParams.PageNumber = 1;
                    }
                    else
                    {
                        filteringParams.FilterString = filteringParams.CurrentFilter;
                    }


                    if (!String.IsNullOrEmpty(filteringParams.FilterString))
                    {
                        vehicleMakes = _context.VehicleMakes.Where(m => m.Name.Contains(filteringParams.FilterString)).AsQueryable();
                                                                               
                    }
                    else vehicleMakes = null;

                    switch (sortingParams.SortOrder)
                    {                        

                        case "name_desc":
                            vehicleMakes = _context.VehicleMakes.OrderByDescending(m => m.Name).AsQueryable();
                            break;                        

                        default:
                            vehicleMakes =  _context.VehicleMakes.OrderBy(m => m.Name).AsQueryable();
                            break;
                    }

                    return _mapper.Map<IList<VehicleMake>>(await PaginationList<VehicleMake>.CreateAsync(vehicleMakes, pagingParams.PageNumber, pagingParams.PageSize ?? 5)).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }
    }
>>>>>>> 3f6d77d7f70c248a71c9f35930ab82abd3d658c0
}
