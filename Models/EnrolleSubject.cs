using System;
using System.Collections.Generic;

namespace practice3.Models;

public partial class EnrolleSubject
{
    public int EnrolleSubjectId { get; set; }

    public int? EnrolleId { get; set; }

    public int? SubjectId { get; set; }

    public int? Result { get; set; }

    public virtual Enrolle? Enrolle { get; set; }

    public virtual Subject? Subject { get; set; }
}
