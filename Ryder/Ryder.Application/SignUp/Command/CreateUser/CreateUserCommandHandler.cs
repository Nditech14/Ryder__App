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

namespace Ryder.Application.SignUp.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IResult>
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<AppUser> _userManager;
        public CreateUserCommandHandler(ApplicationContext context, UserManager<AppUser> userManager )
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //Perform logic for sign up as a User
            var CreateUser = await _userManager.FindByEmailAsync(request.Email);
            if (CreateUser != null) return Result.Fail("User exist");
            CreateUser = new Domain.Entities.AppUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = request.Password,
                UserName = request.Email
            };

            //Perform transaction
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createdUser = await _userManager.CreateAsync(CreateUser, request.Password);
                if (!createdUser.Succeeded) return Result.Fail();
                var CreateRole = await _userManager.AddToRoleAsync(CreateUser, Policies.Customer);
                if (!CreateRole.Succeeded) return Result.Fail();
                transaction.Complete();
                await _context.SaveChangesAsync(cancellationToken);
                return Result.Success("Signup successful");
            }
            
        }
    }
}
