using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    [Table("TeacherClassSubject")]
    public class TeacherClassSubjectEntity
    {
        [Key]
        public int TeacherClassSubjectId { get; set; }
        
        public int TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public TeacherEntity Teacher { get; set; }
        public int ClassId { get; set; }
        [ForeignKey(nameof(ClassId))]

        public ClassEntity Class { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]

        public SubjectEntity Subgect { get; set; }
        public int HoursPerWeek { get; set; }


    }
}
