using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    public class ClassEntity
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int ClassNumber { get; set; }
        public int TotalWeekHours { get; set; }
        public List<ClassSubjectEntity> Subjects { get; set; }



    }
}
