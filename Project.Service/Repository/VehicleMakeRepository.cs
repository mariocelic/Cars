﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Service.Data;
using Project.Service.Helpers;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Repository
{
    public class VehicleMakeRepository : AsyncRepositoryBase<VehicleMake>, IVehicleMakeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public VehicleMakeRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;

        }

        public IQueryable<VehicleMake> FindAllAsync()
        {
            return _context.VehicleMakes.AsNoTracking();
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


                    if (!string.IsNullOrEmpty(filteringParams.FilterString))
                    {
                        vehicleMakes = _context.VehicleMakes.Where(q => q.Name.Contains(filteringParams.FilterString));
                    }
                    else vehicleMakes = null;

                    //sorting
                    switch (sortingParams.SortOrder)
                    {
                        case "name_desc":
                            vehicleMakes = _context.VehicleMakes.OrderByDescending(q => q.Name);
                            break;

                        default:
                            vehicleMakes = vehicleMakes != null ? vehicleMakes.OrderBy(q => q.Name) : _context.VehicleMakes.OrderBy(q => q.Name);
                            break;
                    }

                    return _mapper.Map<IList<VehicleMake>>(await PaginationList<VehicleMake>.CreateAsync(vehicleMakes, pagingParams.PageNumber ?? 1, pagingParams.PageSize ?? 5)).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
