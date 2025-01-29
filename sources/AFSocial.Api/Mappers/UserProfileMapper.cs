using AFSocial.Api.Contracts.UserProfiles.Requests;
using AFSocial.Api.Contracts.UserProfiles.Responses;
using AFSocial.Application.UserProfiles.Commands;
using AFSocial.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Api.Mappers;
public static class UserProfileMapper
{
    public static CreateUserCommand ToUserProfileCommand(this UserProfileCreate source)
    {
        return new CreateUserCommand()
        {
            CurrentCity = source.CurrentCity,
            DateOfBirth = source.DateOfBirth,
            EmailAddress = source.EmailAddress,
            FirstName = source.FirstName,
            LastName = source.LastName,
            PhoneNumber = source.PhoneNumber,
        };
    }

    public static UserProfileResponse ToUserProfileResponse(this UserProfile source)
    {
        return new UserProfileResponse()
        {
            CreatedAt = source.CreatedAt,
            LastModified = source.LastModified,
            UserProfileId = source.UserProfileId,
            BasicInfo = source.BasicInfo.ToBasicInfoResponse(),
        };
    }

    public static BasicInfoResponse ToBasicInfoResponse(this BasicInfo source)
    {
        return new BasicInfoResponse()
        {
            CurrentCity = source.CurrentCity,
            DateOfBirth = source.DateOfBirth,
            EmailAddress = source.EmailAddress,
            FirstName = source.FirstName,
            LastName = source.LastName,
            PhoneNumber = source.PhoneNumber,
        };
    }
}
