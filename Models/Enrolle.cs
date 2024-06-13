using System;
using System.Collections.Generic;

namespace practice3.Models;

public partial class Enrolle
{
    public int EnrolleId { get; set; }

    public string? NameEnrolle { get; set; }

    public virtual ICollection<EnrolleAchievement> EnrolleAchievements { get; set; } = new List<EnrolleAchievement>();

    public virtual ICollection<EnrolleSubject> EnrolleSubjects { get; set; } = new List<EnrolleSubject>();

    public virtual ICollection<ProgramEnrollee> ProgramEnrollees { get; set; } = new List<ProgramEnrollee>();
}
