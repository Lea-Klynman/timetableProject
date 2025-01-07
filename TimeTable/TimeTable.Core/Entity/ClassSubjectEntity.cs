using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    [Table("ClassSubject")]
    public class ClassSubjectEntity
    {
        [Key]
        public int ClassSubjectId { get; set; }
        
        public int SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public SubjectEntity Subject { get; set; }
        
        public int ClassId { get; set; }
        [ForeignKey(nameof(ClassId))]
        public ClassEntity Class { get; set; }
        public int HoursPersWeek { get; set; }


    }
}
