using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Domain.Aggregates.UserProfileAggregate;
public class BasicInfo
{
    private BasicInfo()
    {
    }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string EmailAddress { get; private set; } = string.Empty;
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; private set; } = DateTime.Now;
    public string CurrentCity { get; private set; } = string.Empty;

    public static BasicInfo CreateBasicInfo(
        string firstName,
        string lastName,
        string emailAddress,
        string phoneNumber,
        DateTime dateOfBirth,
        string currentCity)
    {
        return new BasicInfo()
        {
            FirstName = firstName,
            LastName = lastName,
            EmailAddress = emailAddress,
            PhoneNumber = phoneNumber,
            DateOfBirth = dateOfBirth,
            CurrentCity = currentCity,
        };
    }
}
