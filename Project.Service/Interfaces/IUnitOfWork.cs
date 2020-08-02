using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleMakeRepository VehicleMake { get; }
        IVehicleModelRepository VehicleModel { get; }

        Task CommitAsync();
    }
}

