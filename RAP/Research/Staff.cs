using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Entity
{
    public enum PerformanceLabel { POOR, BELOW_EXPECTATION, MEETING_MINIMUM, STAR_PERFORMERS};
    public class Staff : Researcher
    {
        private float performance;
        private float performance_percentage;

        public List<Student> students = new List<Student>();
        public PerformanceLabel PerformanceLabel { get; set; }
        
        public Staff(Researcher r)
        {
            this.ID = r.ID;
            this.GivenName = r.GivenName;
            this.FamilyName = r.FamilyName;
            this.publications = r.publications;
            this.position.Level = r.position.Level;
            this.Email = r.Email;
        }
        public float ThreeYearAverage()
        {
            int cumulativePubThreeYear = publications.Where(p => p.Year >= DateTime.Now.Year - 3 && p.Year < DateTime.Now.Year).Count();
            performance = cumulativePubThreeYear/3.0f;
            return this.performance;
        }
        public float Performance()
        {
            performance = ThreeYearAverage();
            switch (position.Level)
            {                
                case EmploymentLevel.A:
                    performance_percentage = performance / 0.5f * 100.0f;
                    break;
                case EmploymentLevel.B:
                    performance_percentage = performance / 1.0f * 100.0f;
                    break;
                case EmploymentLevel.C:
                    performance_percentage = performance / 2.0f * 100.0f;
                    break;
                case EmploymentLevel.D:
                    performance_percentage = performance / 3.2f * 100.0f;
                    break;
                default:
                    performance_percentage = performance / 4.0f * 100.0f;
                    break;
            }
            return this.performance_percentage;
        }

        public PerformanceLabel ToPerformanceReport(float performance_percentage)
        {
            if (performance_percentage <= 70) PerformanceLabel = PerformanceLabel.POOR;
            else if (performance_percentage > 70 && performance_percentage < 110) PerformanceLabel = PerformanceLabel.BELOW_EXPECTATION;
            else if (performance_percentage >= 110 && performance_percentage < 200) PerformanceLabel = PerformanceLabel.MEETING_MINIMUM;
            else PerformanceLabel = PerformanceLabel.STAR_PERFORMERS;

            return PerformanceLabel;
        }

        public PerformanceLabel PerformanceReport()
        {
            return ToPerformanceReport(Performance());
        }

        public List<Student> SupervisionList(List<Student> students)
        {
            var supervisions = from s in students
                               where s.SupervisorID == this.ID 
                               select s;
            return supervisions.ToList();
        }
        public int Supervisions()
        {
            return SupervisionList(students).Count;
        }
    }
}
