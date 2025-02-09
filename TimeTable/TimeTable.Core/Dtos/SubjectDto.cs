using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Dtos
{
    public class SubjectDto
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public bool IsGroup { get; set; }
    }
}
