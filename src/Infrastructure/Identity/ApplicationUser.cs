﻿using Microsoft.AspNetCore.Identity;
using warehouse_BE.Domain.Entities;

namespace warehouse_BE.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string? CompanyId { get; set; }
    public bool isActived { get; set; }
    public bool isDeleted { get; set; }
    public string? AvatarImage { get; set; }
    public bool isOnline { get; set; }
    public ICollection<UserStorage> UserStorages { get; set; } = new List<UserStorage>();
}
