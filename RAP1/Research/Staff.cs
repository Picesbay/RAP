using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Entity
{
    public enum PerformanceLabel { ALL, POOR, BELOW_EXPECTATION, MEETING_MINIMUM, STAR_PERFORMERS };
    public class Staff : Researcher
    {
        private float performance;
        public float PerformancePercentage { get; set; }
        public PerformanceLabel PerformanceLabel { get; set; }
        public string Name { get { return this.GivenName + " " + this.FamilyName; } set { } }

        public List<Student> students = new List<Student>();

        //public Staff() { }
        public Staff(Researcher r)
        {
            this.ID = r.ID;
            this.GivenName = r.GivenName;
            this.FamilyName = r.FamilyName;
            this.publications = r.publications;
            this.position.Level = r.position.Level;
            this.Email = r.Email;
            Performance();
            PerformanceReport();
        }
        public float ThreeYearAverage
        {
            get
            {
                int cumulativePubThreeYear = publications.Where(p => p.Year >= DateTime.Now.Year - 3 && 
                                                                p.Year < DateTime.Now.Year).Count();
                performance = cumulativePubThreeYear / 3.0f;
                return performance;
            }
        }
        public float Performance()
        {
            performance = ThreeYearAverage;
            switch (position.Level)
            {
                case EmploymentLevel.A:
                    PerformancePercentage = performance / 0.5f * 100.0f;
                    break;
                case EmploymentLevel.B:
                    PerformancePercentage = performance / 1.0f * 100.0f;
                    break;
                case EmploymentLevel.C:
                    PerformancePercentage = performance / 2.0f * 100.0f;
                    break;
                case EmploymentLevel.D:
                    PerformancePercentage = performance / 3.2f * 100.0f;
                    break;
                default:
                    PerformancePercentage = performance / 4.0f * 100.0f;
                    break;
            }
            return PerformancePercentage;
        }

        public PerformanceLabel ToPerformanceReport(float performance_percentage)
        {
            performance_percentage = Performance();

            if (performance_percentage <= 70.0f)
            {
                PerformanceLabel = PerformanceLabel.POOR;
            }
            else if (performance_percentage > 70.0f && performance_percentage < 110.0f)
            {
                PerformanceLabel = PerformanceLabel.BELOW_EXPECTATION;
            }
            else if (performance_percentage >= 110.0f && performance_percentage < 200.0f)
            {
                PerformanceLabel = PerformanceLabel.MEETING_MINIMUM;
            }

            else
            { PerformanceLabel = PerformanceLabel.STAR_PERFORMERS; }
            return PerformanceLabel;
        }

        public PerformanceLabel PerformanceReport()
        {
            return ToPerformanceReport(Performance());
        }

        
        public List<Student> SupervisionList()
        {
            var supervisions = from s in students
                               where s.SupervisorID == this.ID
                               select s;
            return supervisions.ToList();
        }
        public int Supervisions
        {
            get
            {
                return SupervisionList().Count;
            }
        }
    }
}
