using System;
using System.Collections.Generic;

namespace Vu_DbFrist.Models;

public partial class Staff
{
    public decimal StaffId { get; set; }

    public string? Staffname { get; set; }

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public decimal? Salary { get; set; }

    public decimal? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
