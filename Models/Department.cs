using System;
using System.Collections.Generic;

namespace practice3.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? NameDepartment { get; set; }

    public virtual ICollection<Program> Programs { get; set; } = new List<Program>();
}
