using TimeTable.Core.Entity;

namespace TimeTable.Api.PostModels
{
    public class ClassPostModel
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int ClassNumber { get; set; }
        public int TotalWeekHours { get; set; }
    }
}
