using Microsoft.AspNetCore.Identity;

namespace PersonalBrand.Domain.DTOs;

public class UserDTO: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhotoUrl { get; set; }
}