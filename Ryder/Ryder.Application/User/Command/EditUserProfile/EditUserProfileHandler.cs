using AspNetCoreHero.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Ryder.Domain.Context;
using Ryder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.User.Command.EditUserProfile
{
    public class EditUserProfileHandler : IRequestHandler<EditUserProfileComand, IResult>
    {
        private readonly UserManager<AppUser> _appUser;

        public EditUserProfileHandler(UserManager<AppUser> context) => _appUser = context;   

        public async Task<IResult> Handle(EditUserProfileComand request, CancellationToken cancellationToken)
        {
            try
            {
                var update = new AppUser
                {
                    Id = Guid.Parse(request.UserId),
                    FirstName = request.ProfileModel.FirstName,
                    LastName = request.ProfileModel.LastName,
                    Email = request.ProfileModel.Email,
                    PhoneNumber = request.ProfileModel.UserPhoneNumber
                };

                var result = await _appUser.UpdateAsync(update);
                

                if (result.Succeeded) return Result.Success("Update successfull");

                return Result.Fail("Oops Something Went Wrong");

            }
            catch (Exception ex)
            {
                return Result.Fail("Oops Something Went Wrong " + ex.Message);
            }
        }
    }   
}
