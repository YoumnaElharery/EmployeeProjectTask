using System;
using System.Collections.Generic;

namespace EmployeeProjectTask.DAL.Entities;

public partial class EmployeesInfo
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Department { get; set; }

    public decimal? Salary { get; set; }
}
