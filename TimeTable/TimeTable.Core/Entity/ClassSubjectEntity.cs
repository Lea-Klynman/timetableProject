using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    public class ClassSubjectEntity
    {
        [Key]
        public int ClassSubjectId { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public int HoursPersWeek { get; set; }


    }
}
