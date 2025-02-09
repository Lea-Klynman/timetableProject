using System.ComponentModel.DataAnnotations;
using TimeTable.Core.Entity;

namespace TimeTable.Api.PostModels
{
    public class TeacherPostModel
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public List<TeacherClassSubjectEntity> Subjects { get; set; }
        public List<AvailabilityEntity> Availabilities { get; set; }
        public int TotalWeeklyHours { get; set; }
    }
}
