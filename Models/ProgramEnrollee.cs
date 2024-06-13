using System;
using System.Collections.Generic;

namespace practice3.Models;

public partial class ProgramEnrollee
{
    public int ProgramEnrolleeId { get; set; }

    public int? ProgramId { get; set; }

    public int? EnrolleId { get; set; }

    public virtual Enrolle? Enrolle { get; set; }

    public virtual Program? Program { get; set; }
}
