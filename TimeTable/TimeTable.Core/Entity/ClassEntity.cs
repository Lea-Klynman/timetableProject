using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    [Table("Class")]
    public class ClassEntity
    {
        [Key]
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int ClassNumber { get; set; }
        public int TotalWeekHours { get; set; }
        //one to many with classSubject
        public List<ClassSubjectEntity> Subjects { get; set; }



    }
}
