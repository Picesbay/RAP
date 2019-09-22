using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RAP.Entity;
using RAP.Database;

namespace RAP.Controller
{
    
    public class ResearcherController
    {
        //Declare a specific researcher
        public Researcher currentResearcher = new Researcher { ID = 123464 };
        
        
        public List<Researcher> res = new List<Researcher>();
        public List<Researcher> resFiltered = new List<Researcher>();

        public List<int> staffID = new List<int>();
        public List<Student> students = new List<Student>();

        //Load full list of researchers
        public void LoadResearchers()
        {
            res = ERDAdapter.fetchBasicResearcherDetails();
        }


        //Load all details of the current researcher
        public void LoadResearcherDetails()
        {
            currentResearcher = ERDAdapter.completeResearcherDetails(currentResearcher);
        }

        //Load full list of students
        public void LoadStudentDetails()
        {
            students = ERDAdapter.fetchStudentsDetails();
        }

        //Filter by employment level
        public void FilterBy(EmploymentLevel level)
        {
            var filteredByLevel = from r in res
                               where r.position.Level == level
                               select r;
            resFiltered = filteredByLevel.ToList();
        }

        //Filter by name
        public void FilterByName(string name)
        {
            var filteredByName = from r in res
                                 where r.GivenName == name
                                 select r;
            resFiltered = filteredByName.ToList();
        }
        
        //Load full list of staff
        public List<Staff> LoadStaff()
        {
            List<Staff> staffList = new List<Staff>();

            LoadResearchers();

            var researchers = from researcher in res
                          where researcher.position.Level != EmploymentLevel.Student
                          select researcher;

            foreach (var r in researchers.ToList())
            {
                Researcher re = ERDAdapter.completeResearcherDetails(r);
                staffList.Add(new Staff(re));
            }
            return staffList;
        }

        //Performance Reports
        public List<Staff> SortedPerformance (List<Staff> staffList)
        {
            var poorPerfList = from s in staffList
                               where s.PerformanceLabel == PerformanceLabel.POOR
                               orderby s.Performance() ascending
                               select s;

            var belowExpPerfList = from s in staffList
                                   where s.PerformanceLabel == PerformanceLabel.BELOW_EXPECTATION
                                   orderby s.Performance() ascending
                                   select s;

            var meetMinimumPerfList = from s in staffList
                                      where s.PerformanceLabel == PerformanceLabel.MEETING_MINIMUM
                                      orderby s.Performance() descending
                                      select s;

            var starPerfList = from s in staffList
                               where s.PerformanceLabel == PerformanceLabel.STAR_PERFORMERS
                               orderby s.Performance() descending
                               select s;
            staffList = poorPerfList.Concat(belowExpPerfList)
                                    .Concat(meetMinimumPerfList)
                                    .Concat(starPerfList)
                                    .ToList();

            return staffList;
        }


//---------------------------------------------------------------------Test----------------------------------------------------------

        //---------------------------------Test run time of LoadResearchers()---------------------------------------------
        //------------------------------------------------Start------------------------------------------------------------
        public void TestRunTimeLoadResearchers()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            LoadResearchers();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Run time for researchers list: {0}", elapsedMs.ToString());

            watch = System.Diagnostics.Stopwatch.StartNew();
            LoadResearcherDetails();
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Run time for a researcher details: {0}", elapsedMs.ToString());

            watch = System.Diagnostics.Stopwatch.StartNew();
            TestStaff();
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Run time for a teststaff: {0}", elapsedMs.ToString());
        }
        //---------------------------------------------------------End----------------------------------------------------------------------




        //Test function to print out a list of researchers.---------Start-------------------------------------------------------------------------
        public void TestBasicListResearchers()
        {
            res.ForEach(x => { Console.WriteLine(String.Format("{0}, {1} ({2})", x.GivenName, x.FamilyName, x.Title)); });
        }
        //-----------------------------------------------------------End---------------------------------------------------------------------




        //----------------------------------------------------Full Test Start------------------------------------------------------------------------------
        //Test function to print out a researcher details by his/her ID
        public void TestResearcherListByID()
        {

            LoadResearchers();
            LoadResearcherDetails();


            Console.WriteLine("Name: {0} {1}\nTitle:{2}\nUnit: {3}\nCampus: {4}\nEmail: {5}\n" +
                                  "Photo: {6}\nCurrent job: {7}\nCommenced with institution: {8}\n" +
                                  "Commenced current position: {9}\nPrevious positions: \n",
                                  currentResearcher.GivenName, currentResearcher.FamilyName, currentResearcher.Title, currentResearcher.Unit, 
                                  currentResearcher.Campus, currentResearcher.Email, currentResearcher.Photo,
                                  currentResearcher.GetCurrentJob().Title(), currentResearcher.GetEarliestJob().Start.ToString("dd/MM/yyyy"),
                                  currentResearcher.GetCurrentJob().Start.ToString("dd/MM/yyyy"));

            //Test to print all the positions of the researcher (not include student)
            foreach (Position pos in currentResearcher.positions)
            {
                if (pos.End != default)
                {
                    Console.WriteLine(String.Format("{0}\t{1}\t{2}\n", pos.Start.ToString("dd/MM/yyyy"),
                                                            pos.End.ToString("dd/MM/yyyy"), pos.Title()));
                };
            }
            Console.WriteLine("Tenure: {0}\tPublications: {1}\n", currentResearcher.Tenure().ToString("0.0"), 
                                currentResearcher.PublicationsCount());
            //List of publication
            PublicationsController pc = new PublicationsController();
            List<Publication> sortedPub = pc.SortPublicationList(currentResearcher);
            foreach (Publication pub in sortedPub)
            {
                Console.WriteLine("Year: {0}\tTitle: {1}",pub.Year,pub.Title);
            }


            //Staff information
            Console.WriteLine("More information: \n");
            LoadStudentDetails();


            if (currentResearcher.position.Level != EmploymentLevel.Student)
            {
                Staff staff = new Staff(currentResearcher)
                {
                    students = students
                };
                TestStaff();
                DisplayNumberOfSupervisions(staff);
            }

            //Student information
            else
            {
                Student s = (from stu in students
                            where stu.ID == currentResearcher.ID
                            select stu).SingleOrDefault();
                DisplayDegreeForStudent(s);
                DisplaySupervisorName(s, res);
            }

            Console.WriteLine("Publication count:\n");
            pc.TestPublicationsCount(currentResearcher);



            //Console.WriteLine("Publication details: \n");
            //pc.loadPublicationsFor(current_researcher);
            //pc.TestPublicationDetails(current_researcher);

        }
        //-----------------------------------------------------------------End------------------------------------------------------------------




        //---------------------------------------Test Performance Report------------------------------------------------------------
        //----------------------------------------------Start------------------------------------------------------------
        public void DisplayPerfReport()
        {
            LoadResearchers();
            LoadResearcherDetails();
            List<Staff> staffList = LoadStaff();
            staffList = SortedPerformance(staffList);
            Console.WriteLine(string.Format("{0,-20} | {1,-20} | {2,-20} | {3,-20}",
                                            "Performance", "Performance Metric", "Name", "Email"));
            foreach (var c in staffList)
            {
                
                Console.WriteLine(string.Format("{0,-20} | {1,-20} | {2,-20} | {3,-20}",
                                  c.PerformanceReport(), c.Performance(), c.GivenName + " " + c.FamilyName, c.Email));
            }
        }

        //---------------------------------------------End---------------------------------------------------------------------------




        //Test function to print out the details of all researchers-----------------------------------------------------------
        //-------------------------------------------------Start-----------------------------------------------------------
        public void TestResearcherListFull()
        {
            //PublicationsController pubic = new PublicationsController();

            foreach (Researcher current_researcher in res)
            {
                //Test to print the full information
                Console.WriteLine("Name: {0} {1}\nTitle:{2}\nUnit: {3}\nCampus: {4}\nEmail: {5}\n" +
                                  "Photo: {6}\nCurrent job: {7}\nCommenced with institution: {8}\n" +
                                  "Commenced current position: {9}\nPrevious positions: \n",
                                  current_researcher.GivenName, current_researcher.FamilyName, current_researcher.Title, 
                                  current_researcher.Unit, current_researcher.Campus, current_researcher.Email, current_researcher.Photo,
                                  current_researcher.GetCurrentJob().Title(), current_researcher.GetEarliestJob().Start.ToString("dd/MM/yyyy"),
                                  current_researcher.GetCurrentJob().Start.ToString("dd/MM/yyyy"));

                //Test to print all the positions of the researcher (not include student)
                foreach (Position pos in current_researcher.positions)
                {
                    if (pos.Level != EmploymentLevel.Student)
                    {
                        Console.WriteLine(String.Format("{0}\t{1}\t{2}\n", pos.Start.ToString("dd/MM/yyyy"),
                                                                pos.End.ToString("dd/MM/yyyy"), pos.Title()));
                    };
                }

                //Test to print basic information of publication
                Console.WriteLine("Tenure: {0}\tPublications: {1}\n", current_researcher.Tenure().ToString("0.0"), 
                                   current_researcher.PublicationsCount());

            }
        }
        //-----------------------------------------------------End------------------------------------------------------------




        //Test function to display tabular view of researcher's cumulative number of publications by year
        //-----------------------------------------------------Start----------------------------------------------------
        public void TestPublicationsCount()
        {
            LoadResearcherDetails();
            PublicationsController p = new PublicationsController();
            p.TestPublicationsCount(currentResearcher);
        }
        //-------------------------------------------------------End----------------------------------------------------------




        //-----------------------------------------Test Staff and Student function--------------------------------------------------
        
        //------------------------------------------------------Start--------------------------------------------------------
     
        public void TestStaff()
        {
            if (currentResearcher.position.Level != EmploymentLevel.Student)
            {
                Staff s = new Staff(currentResearcher);
                Console.WriteLine("Level: {0}, ID: {1}", s.position.Level, s.ID);
                Console.WriteLine("Three year average: {0}\nPerformance: {1}", s.ThreeYearAverage(), s.Performance());
            } 
        }
        //---------------------------------------------------------End---------------------------------------------------------




        //------------------------------------------Test student degree-------------------------------------------------------
        //--------------------------------------------------------Start--------------------------------------------------------
        public void DisplayDegreeForStudent(Student s)
        {
            if (currentResearcher.position.Level == EmploymentLevel.Student)
            {
                Console.WriteLine("Student degree: {0}", s.Degree);
            }
        }
        //-------------------------------------------------------End-----------------------------------------------------------




        //----------------------------------------Test supervisor name of student----------------------------------------------
        //-------------------------------------------------------Start---------------------------------------------------------
        public void DisplaySupervisorName(Student s, List<Researcher> r)
        {
            Console.WriteLine("Supervisors Name: {0}", s.SupervisorsName(r));
        }
        //-------------------------------------------------------End--------------------------------------------------------------




        //----------------------------------------Test number of supervisions in staff-------------------------------------------
        //---------------------------------------------------Start--------------------------------------------------------------
        public void DisplayNumberOfSupervisions(Staff s)
        {
            Console.WriteLine("Supervisions: {0}", s.Supervisions());
        }
        //----------------------------------------------------End----------------------------------------------------------------
               
    }
}
