using Ryder.Domain.Context;
using Ryder.Domain.Entities;
using Ryder.Domain.Enums;
using Ryder.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Infrastructure.Implementation
{
    public class RiderService : IRiderService
    {
        private readonly ApplicationContext _context; // Inject your database context here

        public RiderService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> SetRiderAvailabilityAsync(string riderId, bool isAvailable)
        {
            try
            {
                var rider = _context.Riders.FirstOrDefault(r => r.AppUserId.ToString() == riderId);

                if (rider != null)
                {
                    if (rider.AvailabilityStatus == RiderAvailabilityStatus.Available)
                    {
                        isAvailable = true;

                        await _context.SaveChangesAsync();
                        return true; // Availability updated successfully

                    }

                    
                }
                return false; // Rider not found
            }
            catch (Exception ex)
            {
                throw ex; // Handle exceptions as needed
            }
        }

        public List<Rider> GetAvailableRiders()
        {
            try
            {
                var availableRiders = _context.Riders.Where(r => r.AvailabilityStatus == RiderAvailabilityStatus.Available).ToList();
                return availableRiders;
            }
            catch (Exception ex)
            {
                throw ex; // Handle exceptions as needed
            }
        }
    }
}
