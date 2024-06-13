using System;
using System.Collections.Generic;

namespace practice3.Models;

public partial class EnrolleAchievement
{
    public int EnrolleAchievId { get; set; }

    public int? EnrolleId { get; set; }

    public int? AchievementId { get; set; }

    public virtual Achievement? Achievement { get; set; }

    public virtual Enrolle? Enrolle { get; set; }
}
