using System;
using System.Collections.Generic;

namespace Vu_DbFrist.Models;

public partial class Company
{
    public decimal CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyDescription { get; set; }

    public string? CompanyPhone { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
