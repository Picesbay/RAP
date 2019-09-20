using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Entity
{
    public class Staff : Researcher
    {
        public List<Student> supervision;
        public float ThreeYearAverage()
        {
            return 0;
        }
        public float Performance()
        {
            return 0;
        }

        public int Supervisions()
        {
            return supervision.Count;
        }
    }
}
