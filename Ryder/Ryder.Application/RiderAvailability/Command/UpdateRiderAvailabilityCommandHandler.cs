using AspNetCoreHero.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ryder.Application.RiderAvailability.Query;
using Ryder.Domain.Context;
using Ryder.Domain.Entities;
using Ryder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.RiderAvailability.Command
{
    public class UpdateRiderAvailabilityCommandHandler : IRequestHandler<UpdateRiderAvailabilityCommand, IResult<RiderAvailabilityResponse>>
    {

        private readonly ApplicationContext _Context;

        public UpdateRiderAvailabilityCommandHandler(ApplicationContext Context)
        {
            _Context = Context;
        }
        public async Task<IResult<RiderAvailabilityResponse>> Handle(UpdateRiderAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var rider = await _Context.Riders.FindAsync(request.RiderId);

            if (rider == null)
            {
                return await Result<RiderAvailabilityResponse>.FailAsync();
            }

            rider.AvailabilityStatus = request.AvailabilityStatus;

            await _Context.SaveChangesAsync(cancellationToken);

            return await Result<RiderAvailabilityResponse>.SuccessAsync();
        }
    }
}
    

