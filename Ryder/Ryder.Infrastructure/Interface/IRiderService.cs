using Ryder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Infrastructure.Interface
{

    public interface IRiderService
    {
        Task<bool> SetRiderAvailabilityAsync(string riderId, bool isAvailable);
        List<Rider> GetAvailableRiders();
    }
}
