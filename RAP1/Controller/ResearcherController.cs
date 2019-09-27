using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RAP.Entity;
using RAP.Database;
using System.Collections.ObjectModel;

namespace RAP.Controller
{
    public class ResearcherController
    {

        private List<Researcher> researchers = new List<Researcher>();

        private ObservableCollection<Researcher> viewableResearchers;
        public ObservableCollection<Researcher> VisibleResearchers { get { return viewableResearchers; } set { } }


        private List<Staff> listStaff = new List<Staff>();
        private ObservableCollection<Staff> viewableStaffPerf;
        public ObservableCollection<Staff> VisibleStaffPerf { get { return viewableStaffPerf; } set { } }

        private List<Student> students = new List<Student>();
        private ObservableCollection<Student> viewableStudents;
        public ObservableCollection<Student> VisibleStudents { get { return viewableStudents; } set { } }


        //ReseacherController constructors
        public ResearcherController()
        {
            researchers = ERDAdapter.fetchBasicResearcherDetails();
            viewableResearchers = new ObservableCollection<Researcher>(researchers);
        }

        public ObservableCollection<Researcher> GetViewableList()
        {
            return VisibleResearchers;
        }
        
        //Filter by level
        public void FilterByLevel(EmploymentLevel level)
        {
            var filteredByLevel = from r in researchers
                                  where r.position.Level == level || level == EmploymentLevel.All
                                  select r;

            viewableResearchers.Clear();
            filteredByLevel.ToList().ForEach(viewableResearchers.Add);
        }

        //Filter by name
        public void FilterByName(string name)
        {
            var filteredByName = from r in researchers
                                 where (r.GivenName + ", " + r.FamilyName).ToUpper().Contains(name.ToUpper()) 
                                 select r;
            viewableResearchers.Clear();
            filteredByName.ToList().ForEach(viewableResearchers.Add);
        }

        ////Load all details of the current researcher
        public Researcher LoadResearcherDetails(Researcher r)
        {
            Researcher currentResearcher = ERDAdapter.completeResearcherDetails(r);
            return currentResearcher;
        }


        //Load full list of students
        public void LoadStudentDetails()
        {
            students = ERDAdapter.fetchStudentsDetails();
            viewableStudents = new ObservableCollection<Student>(students);
        }

        public ObservableCollection<Student> GetViewableStudents()
        {
            LoadStudentDetails();
            return VisibleStudents;
        }


        ////--------------------------------------------------Use Case 43: User generate reports---------------------------------------------
        /////
        /////Load full list of staff
        /////
        public void LoadStaff()
        {
            
            foreach (var r in researchers)
            {
                if (r.position.Level != EmploymentLevel.Student)
                {
                    Researcher re = ERDAdapter.completeResearcherDetails(r);

                    listStaff.Add(new Staff(re)) ;
                }
            }
            SortedPerformance();
        }



        //Performance Reports
        public void SortedPerformance()
        {
            var lowPerformance = from s in listStaff
                                 where s.PerformanceLabel == PerformanceLabel.POOR || s.PerformanceLabel == PerformanceLabel.BELOW_EXPECTATION
                                 orderby s.Performance() ascending
                                 select s;

            var highPerformance = from s in listStaff
                                  where s.PerformanceLabel == PerformanceLabel.MEETING_MINIMUM || s.PerformanceLabel == PerformanceLabel.STAR_PERFORMERS
                                  orderby s.Performance() descending
                                  select s;

            listStaff = lowPerformance.Concat(highPerformance).ToList();
            viewableStaffPerf = new ObservableCollection<Staff>(listStaff);

        }


        public ObservableCollection<Staff> GetViewableStaffPerf()
        {
            LoadStaff();
            return VisibleStaffPerf;
        }


        //Filter by Report
        public void FilterByReport(PerformanceLabel perfLabel)
        {
            var filteredByReport = from r in listStaff
                                   where r.PerformanceLabel == perfLabel || perfLabel == PerformanceLabel.ALL
                                   select r;

            viewableStaffPerf.Clear();
            filteredByReport.ToList().ForEach(viewableStaffPerf.Add);

        }



        ////---------------------------------------------------------------------Test----------------------------------------------------------



        ////---------------------------------Test function to print out a list of researchers------------------------------------------
        ////---------------------------------------------------------Start-------------------------------------------------------------------------
        //public void TestBasicListResearchers()
        //{
        //    LoadResearchers();
        //    researchers.ForEach(x => { Console.WriteLine(String.Format("{0,-10} {1} ({2})", x.GivenName + ",", x.FamilyName, x.Title)); });
        //}
        ////-----------------------------------------------------------End---------------------------------------------------------------------



        ////----------------------------------Test to print all the researcher details and publications---------------------------
        ////----------------------------------------------------Full Test Start------------------------------------------------------------------------------

        //public void TestResearcherListByID(int id)
        //{

        //    LoadResearcherDetails(new Researcher { ID = id });


        //    Console.WriteLine("Name: {0} {1}\nTitle:{2}\nUnit: {3}\nCampus: {4}\nEmail: {5}\n" +
        //                          "Photo: {6}\nCurrent job: {7}\nCommenced with institution: {8}\n" +
        //                          "Commenced current position: {9}\nPrevious positions: \n",
        //                          currentResearcher.GivenName, currentResearcher.FamilyName, currentResearcher.Title, currentResearcher.Unit,
        //                          currentResearcher.Campus, currentResearcher.Email, currentResearcher.Photo,
        //                          currentResearcher.GetCurrentJob().Title(), currentResearcher.GetEarliestJob().Start.ToString("dd/MM/yyyy"),
        //                          currentResearcher.GetCurrentJob().Start.ToString("dd/MM/yyyy"));

        //    //Test to print all the positions of the researcher (not include student)
        //    foreach (Position pos in currentResearcher.positions)
        //    {
        //        if (pos.End != default)
        //        {
        //            Console.WriteLine(String.Format("{0}\t{1}\t{2}\n", pos.Start.ToString("dd/MM/yyyy"),
        //                                                    pos.End.ToString("dd/MM/yyyy"), pos.Title()));
        //        };
        //    }
        //    Console.WriteLine("Tenure: {0}\tPublications: {1}\n", currentResearcher.Tenure().ToString("0.0"),
        //                        currentResearcher.PublicationsCount());



        //    //Staff information
        //    Console.WriteLine("More information: \n");
        //    LoadStudentDetails();


        //    if (currentResearcher.position.Level != EmploymentLevel.Student)
        //    {
        //        Staff staff = new Staff(currentResearcher)
        //        {
        //            students = students
        //        };
        //        TestStaff();
        //        DisplayNumberOfSupervisions(staff);
        //    }

        //    //Student information
        //    else
        //    {
        //        Student s = (from stu in students
        //                     where stu.ID == currentResearcher.ID
        //                     select stu).SingleOrDefault();
        //        DisplayDegreeForStudent(s);
        //        DisplaySupervisorName(s, researchers);
        //    }



        //    //List of publication
        //    PublicationsController pc = new PublicationsController();
        //    List<Publication> sortedPub = pc.SortPublicationList(currentResearcher);

        //    Console.WriteLine("Publication count:");
        //    pc.TestPublicationsCount(currentResearcher);

        //    Console.WriteLine("{0,-10}  {1}\n", "Year", "Title");
        //    foreach (Publication pub in sortedPub)
        //    {
        //        Console.WriteLine("{0,-10}  {1}\n", pub.Year, pub.Title);
        //    }

        //    Console.WriteLine("Publication details: \n");
        //    pc.LoadPublicationsFor(currentResearcher);
        //    pc.TestPublicationDetails(currentResearcher);

        //}
        ////-----------------------------------------------------------------End------------------------------------------------------------------




        ////---------------------------------------Test Performance Report------------------------------------------------------------
        ////----------------------------------------------Start------------------------------------------------------------
        //public void DisplayPerfReport()
        //{
        //    LoadResearchers();
        //    LoadResearcherDetails(currentResearcher);
        //    List<Staff> staffList = LoadStaff();
        //    staffList = SortedPerformance(staffList);
        //    Console.WriteLine(string.Format("{0,-20} | {1,-20} | {2,-20} | {3,-20}",
        //                                    "Performance", "Performance Metric", "Name", "Email"));
        //    foreach (var c in staffList)
        //    {

        //        Console.WriteLine(string.Format("{0,-20} | {1,-20} | {2,-20} | {3,-20}",
        //                          c.PerformanceReport(), c.Performance().ToString("0.0"), c.GivenName + " " + c.FamilyName, c.Email));
        //    }
        //}

        ////---------------------------------------------End---------------------------------------------------------------------------




        ////Test function to print out the details of all researchers-----------------------------------------------------------
        ////-------------------------------------------------Start-----------------------------------------------------------
        //public void TestResearcherListFull()
        //{
        //    //PublicationsController pubic = new PublicationsController();
        //    LoadResearchers();

        //    foreach (Researcher current_researcher in researchers)
        //    {
        //        //Test to print the full information
        //        TestResearcherListByID(current_researcher.ID);

        //    }
        //}
        ////-----------------------------------------------------End------------------------------------------------------------




        ////Test function to display tabular view of researcher's cumulative number of publications by year
        ////-----------------------------------------------------Start----------------------------------------------------
        //public void TestPublicationsCount()
        //{
        //    LoadResearcherDetails(currentResearcher);
        //    PublicationsController p = new PublicationsController();
        //    p.TestPublicationsCount(currentResearcher);
        //}
        ////-------------------------------------------------------End----------------------------------------------------------





        ////-----------------------------------------Test functions run in TestResearcherListByID ------------------------------------------

        ////------------------------------------------------------Start--------------------------------------------------------

        //public void TestStaff()
        //{
        //    if (currentResearcher.position.Level != EmploymentLevel.Student)
        //    {
        //        Staff s = new Staff(currentResearcher);
        //        Console.WriteLine("Level: {0}, ID: {1}", s.position.Level, s.ID);
        //        Console.WriteLine("Three year average: {0}\nPerformance: {1}", s.ThreeYearAverage(), s.Performance());
        //    }
        //}
        ////---------------------------------------------------------End---------------------------------------------------------




        ////------------------------------------------Test student degree-------------------------------------------------------
        ////--------------------------------------------------------Start--------------------------------------------------------
        //public void DisplayDegreeForStudent(Student s)
        //{
        //    if (currentResearcher.position.Level == EmploymentLevel.Student)
        //    {
        //        Console.WriteLine("Student degree: {0}", s.Degree);
        //    }
        //}
        ////-------------------------------------------------------End-----------------------------------------------------------




        ////----------------------------------------Test supervisor name of student----------------------------------------------
        ////-------------------------------------------------------Start---------------------------------------------------------
        //public void DisplaySupervisorName(Student s, List<Researcher> r)
        //{
        //    Console.WriteLine("Supervisors Name: {0}", s.SupervisorsName(r));
        //}
        ////-------------------------------------------------------End--------------------------------------------------------------




        ////----------------------------------------Test number of supervisions in staff-------------------------------------------
        ////---------------------------------------------------Start--------------------------------------------------------------
        //public void DisplayNumberOfSupervisions(Staff s)
        //{
        //    Console.WriteLine("Supervisions: {0}", s.Supervisions());
        //}
        ////----------------------------------------------------End----------------------------------------------------------------





        ////---------------------------------Test run time of LoadResearchers()---------------------------------------------
        ////------------------------------------------------Start------------------------------------------------------------
        //public void TestRunTimeLoadResearchers()
        //{
        //    var watch = System.Diagnostics.Stopwatch.StartNew();
        //    LoadResearchers();
        //    watch.Stop();
        //    var elapsedMs = watch.ElapsedMilliseconds;
        //    Console.WriteLine("Run time for researchers list: {0}", elapsedMs.ToString());

        //    watch = System.Diagnostics.Stopwatch.StartNew();
        //    LoadResearcherDetails(currentResearcher);
        //    watch.Stop();
        //    elapsedMs = watch.ElapsedMilliseconds;
        //    Console.WriteLine("Run time for a researcher details: {0}", elapsedMs.ToString());

        //    watch = System.Diagnostics.Stopwatch.StartNew();
        //    LoadStaff();
        //    watch.Stop();
        //    elapsedMs = watch.ElapsedMilliseconds;
        //    Console.WriteLine("Run time for a teststaff: {0}", elapsedMs.ToString());

        //    watch = System.Diagnostics.Stopwatch.StartNew();
        //    List<Staff> staffList = LoadStaff();
        //    SortedPerformance(staffList);
        //    watch.Stop();
        //    elapsedMs = watch.ElapsedMilliseconds;
        //    Console.WriteLine("Run time for a teststaff: {0}", elapsedMs.ToString());

        //}
        ////---------------------------------------------------------End----------------------------------------------------------------------



    }
}
