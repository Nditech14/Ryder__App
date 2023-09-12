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
        private readonly UserManager<Rider> _manager;
        public CreateRiderCommandHandler(ApplicationContext context, UserManager<AppUser> userManager, UserManager<Rider> manager)
        {
            _context = context;
            _userManager = userManager;
            _manager = manager;
        }
        public async Task<IResult> Handle(CreateRiderCommand request, CancellationToken cancellationToken)
        {
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

            var riderDocumentation = await _manager.FindByIdAsync(request.ValidIdUrl);
            if (riderDocumentation != null) return Result.Fail("Document already exist");
            riderDocumentation = new Domain.Entities.Rider()
            {
                ValidIdUrl = request.ValidIdUrl,
                PassportPhoto = request.PassportPhoto,
                BikeDocument = request.BikeDocument
            };

            using(var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdRider = await _userManager.CreateAsync(createRider, request.Password);
                if (!createdRider.Succeeded) return Result.Fail();
                var riderDocuments = await _manager.CreateAsync(riderDocumentation);
                if (!riderDocuments.Succeeded) return Result.Fail();
                var CreateRole = await _userManager.AddToRoleAsync(createRider, Policies.Rider);
                if (!CreateRole.Succeeded) return Result.Fail();
                transaction.Complete();
                await _context.SaveChangesAsync(cancellationToken);
                return Result.Success("Signup successful");


            }
        }
    }
}
