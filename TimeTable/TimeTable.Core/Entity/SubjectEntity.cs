using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    [Table("Subject")]
    public class SubjectEntity
    {
        [Key]
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public bool IsGroup { get; set; }


    }
}
