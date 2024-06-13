using System;
using System.Collections.Generic;

namespace practice3.Models;

public partial class Achievement
{
    public int AchievementId { get; set; }

    public string? NameAchievement { get; set; }

    public decimal? Bonus { get; set; }

    public virtual ICollection<EnrolleAchievement> EnrolleAchievements { get; set; } = new List<EnrolleAchievement>();
}
