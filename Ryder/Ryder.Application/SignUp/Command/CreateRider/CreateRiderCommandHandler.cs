using AspNetCoreHero.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Ryder.Domain.Context;
using Ryder.Domain.Entities;
using Ryder.Infrastructure.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Ryder.Application.SignUp.Command.CreateRider
{
    public class CreateRiderCommandHandler : IRequestHandler<CreateRiderCommand, IResult>
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<AppUser> _userManager;
     
        public CreateRiderCommandHandler(ApplicationContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IResult> Handle(CreateRiderCommand request, CancellationToken cancellationToken)
        {
            //Perform logic for sign up as a Rider
            var createRider = await _userManager.FindByEmailAsync(request.Email);
            if (createRider != null) return Result.Fail("Rider exist");
            createRider = new Domain.Entities.AppUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = request.Password,
                UserName = request.Email
            };

            var riderDocumentation = new Domain.Entities.Rider()
            {
                ValidIdUrl = request.ValidIdUrl,
                PassportPhoto = request.PassportPhoto,
                BikeDocument = request.BikeDocument
            };

            //Perform transaction and save to Db
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdRider = await _userManager.CreateAsync(createRider, request.Password);
                if (!createdRider.Succeeded) return Result.Fail();
                var CreateRole = await _userManager.AddToRoleAsync(createRider, Policies.Rider);
                if (!CreateRole.Succeeded) return Result.Fail();
                await _context.Riders.AddAsync(riderDocumentation);
                transaction.Complete();
                await _context.SaveChangesAsync(cancellationToken);
                return Result.Success("Signup successful");


            }
        }
    }
}
