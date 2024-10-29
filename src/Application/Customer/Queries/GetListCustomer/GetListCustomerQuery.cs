﻿using warehouse_BE.Application.Common.Interfaces;
using warehouse_BE.Application.Common.Models;
using warehouse_BE.Application.Customer.Queries.GetListCustomer;

namespace warehouse_BE.Application.Customer.Queries.GetLlistCustomer;

public class GetListCustomerQuery : IRequest<EmployeeListVM>
{
    public Page? Page { get; set; }
}
public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, EmployeeListVM>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;
    private readonly IUser _currentUser;
    public GetListCustomerQueryHandler(IApplicationDbContext context
        , IMapper mapper
        ,IIdentityService identityService
        ,IUser currentUser)
    {
        _context = context;
        _mapper = mapper;
        _identityService = identityService;
        _currentUser = currentUser;
    }
    public async Task<EmployeeListVM> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
    {
        var rs = new EmployeeListVM();
        if (string.IsNullOrEmpty(_currentUser?.Id))
        {
            return rs;
        }
        var companyIdResult = await _identityService.GetCompanyId(_currentUser.Id);
        if(companyIdResult.CompanyId != null)
        {
            var customers = await _identityService.GetUsersByRoleAsync("Customer",companyIdResult.CompanyId);
            if (customers.Count > 0)
            {
                var employeeList = customers.Select(c => new EmployeeDto
                {
                    Id = c.Id,
                    CompanyId = c.CompanyId,
                    UserName = c.UserName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    isActived = c.isActived,
                    AvatarImage = c.AvatarImage
                }).ToList();

                // Pagination logic
                rs.Employees = employeeList
                    .Skip((request.Page?.PageNumber - 1 ?? 0) * (request.Page?.Size ?? 1))
                    .Take(request.Page?.Size ?? 10)
                    .ToList();

                rs.Page = new Page
                {
                    Size = request.Page?.Size ?? 0,
                    PageNumber = request.Page?.PageNumber ?? 1,
                    TotalElements = customers.Count,
                };
            }
        }
        return rs;
    }
}
