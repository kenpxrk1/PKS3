using System;
using System.Collections.Generic;

namespace practice3.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string? NameSubject { get; set; }

    public virtual ICollection<EnrolleSubject> EnrolleSubjects { get; set; } = new List<EnrolleSubject>();

    public virtual ICollection<ProgramSubject> ProgramSubjects { get; set; } = new List<ProgramSubject>();
}
