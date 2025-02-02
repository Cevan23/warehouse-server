﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse_BE.Application.Employee.Commands.CreateEmployee;

public class EmployeeRequest
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email {  get; set; }
    public string? PhoneNumber { get; set; }
    public required string CompanyId { get; set; }
    public List<int>? Warehouses { get; set; }
}
