using System.Collections.Generic;

namespace DayPlannerAPI.Models
{
    public class User
    {
        public int Id { get; set; } 

        // Navigation property
        public ICollection<PlannedActivity> PlannedActivities { get; set; }
    }
}