using System;
using System.Collections.Generic;

namespace practice3.Models;

public partial class ProgramSubject
{
    public int ProgramSubjectId { get; set; }

    public int? ProgramId { get; set; }

    public int? SubjectId { get; set; }

    public int? MinResult { get; set; }

    public virtual Program? Program { get; set; }

    public virtual Subject? Subject { get; set; }
}
