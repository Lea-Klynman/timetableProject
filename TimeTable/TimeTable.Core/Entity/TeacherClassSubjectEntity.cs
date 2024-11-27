using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    public class TeacherClassSubjectEntity
    {
        public int TeacherClassSubjectId { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int HoursPerWeek { get; set; }


    }
}
