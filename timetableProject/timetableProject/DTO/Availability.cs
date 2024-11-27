namespace timetableProject.DTO
{
    public class Availability
    {
        public int AvailabilityId { get; set; }
        public string DayOfWeek { get; set; }
        public string Unavailablehours { get; set; }
        public bool IsWholeDayOff { get; set; }
        public bool isMust { get; set; }

    }
}
