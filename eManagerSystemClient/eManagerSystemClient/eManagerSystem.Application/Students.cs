using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eManagerSystem.Application
{
    [Serializable]
   public class Students
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int MSSV { get; set; }

        public int CurrentGradeId { get; set; }

        public int CurrentSubjectId { get; set; }

        public string FullName { get { return LastName + FirstName; } }
    }
}
