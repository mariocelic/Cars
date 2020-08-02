using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Service.Data;
using Project.Service.DTO;
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
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public VehicleMakeRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleMake>> FindAllMakes()
        {

            var models = await _context.Set<VehicleMake>()
               .AsNoTracking()               
               .ToListAsync(); 
            return models;

        }

    }
}
