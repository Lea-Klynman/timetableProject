using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    [Table("Teacher")]
    public class TeacherEntity
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Id { get; set; }
        //one to mamy with tacherClassSubjecct
        public  List<TeacherClassSubjectEntity> Subjects { get; set; }
        //one to many with Availabilities
        public  List<AvailabilityEntity> Availabilities { get; set; }
        public int TotalWeeklyHours { get; set; }

    }
}
