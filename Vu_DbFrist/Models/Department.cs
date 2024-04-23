using System;
using System.Collections.Generic;

namespace Vu_DbFrist.Models;

public partial class Department
{
    public decimal DepartmentId { get; set; }

    public string? Departmentname { get; set; }

    public int? QuantityStaff { get; set; }

    public decimal? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
