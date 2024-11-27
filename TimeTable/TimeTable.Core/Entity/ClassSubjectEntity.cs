using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    public class ClassSubjectEntity
    {
        public int ClassSubjectId { get; set; }
        public int SubjectId { get; set; }
        public int ClassId { get; set; }
        public int HoursPersWeek { get; set; }


    }
}
