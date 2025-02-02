﻿using System.Security.Claims;

using warehouse_BE.Application.Common.Interfaces;

namespace warehouse_BE.Web.Services;

public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    public string? IP => _httpContextAccessor.HttpContext?.Request.Headers["X-Forwarded-For"].FirstOrDefault() ??
                                _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();

}
