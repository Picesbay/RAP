using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Entity
{
    public enum EmploymentLevel { Student, A, B, C, D, E }
    public class Position
    {
        private string title = "";
        public EmploymentLevel Level { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title()
        {
            return ToTitle(Level);
        }
        public string ToTitle(EmploymentLevel level)
        {
            switch (level)
            {
                case EmploymentLevel.A:
                    title = "Postdoc";
                    break;
                case EmploymentLevel.B:
                    title = "Lecturer";
                    break;
                case EmploymentLevel.C:
                    title = "Senior Lecturer";
                    break;
                case EmploymentLevel.D:
                    title = "Associate Professor";
                    break;
                case EmploymentLevel.E:
                    title = "Professor";
                    break;
                default:
                    title = "Student";
                    break;
            }
            return title;
        }


    }
}
