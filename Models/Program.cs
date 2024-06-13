using System;
using System.Collections.Generic;

namespace practice3.Models;

public partial class Program
{
    public int ProgramId { get; set; }

    public string? NameProgram { get; set; }

    public int? DepartmentId { get; set; }

    public string? Plan { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<ProgramEnrollee> ProgramEnrollees { get; set; } = new List<ProgramEnrollee>();

    public virtual ICollection<ProgramSubject> ProgramSubjects { get; set; } = new List<ProgramSubject>();
}
