using AspNetCoreHero.Results;
using MediatR;
using Ryder.Application.RiderAvailability.Query;
using Ryder.Domain.Context;
using Ryder.Domain.Entities;
using Ryder.Domain.Enums;

namespace Ryder.Application.Riders.Handlers
{
    public class GetRiderAvailabilityHandler : IRequestHandler<GetRiderAvailabilityQuery, IResult<GetRiderAvailabilityResponse>>
    {
        private readonly ApplicationContext _Context;

        public GetRiderAvailabilityHandler(ApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<IResult<GetRiderAvailabilityResponse>> Handle(GetRiderAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var rider = await _Context.Riders.FindAsync(request.RiderId);

            if (rider == null)
            {
                return await Result<GetRiderAvailabilityResponse>.FailAsync();
            }
            var RiderAvailabilityStatus = new Rider
            {
                AvailabilityStatus = request.AvailabilityStatus
            };

            return await Result<GetRiderAvailabilityResponse>.SuccessAsync();
       
        }
    }
} 
