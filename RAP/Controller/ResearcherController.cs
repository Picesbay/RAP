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
        public Researcher current_researcher = new Researcher();
        public List<Researcher> res = new List<Researcher>();
        public void LoadResearchers()
        {
            res = ERDAdapter.fetchBasicResearcherDetails();
        }

        public void FilterBy(EmploymentLevel level) { }
        public void FilterByName(string name) { }
        public void LoadResearcherDetails(int id)
        {
            LoadResearchers();
            current_researcher = ERDAdapter.fetchFullResearcherDetails(id);
            current_researcher = ERDAdapter.completeResearcherDetails(current_researcher);
        }



        //---------------------------------------------------------------------Test-------------------------------------------------

        //Test run time of LoadResearchers()
        public void TestRunTimeLoadResearchers()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            LoadResearchers();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Run time for researchers list: {0}", elapsedMs.ToString());

            watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            LoadResearcherDetails(123460);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Run time for a researcher details: {0}", elapsedMs.ToString());
        }



        //Test function to print out a list of researchers.
        public void TestBasicListResearchers()
        {
            res.ForEach(x => { Console.WriteLine(String.Format("{0}, {1} ({2})", x.GivenName, x.FamilyName, x.Title)); });
        }

        //Test function to print out a researcher details by his/her ID
        public void TestResearcherListByID()
        {
            Console.WriteLine("Input ID: ");
            int id = Int32.Parse(Console.ReadLine());
            LoadResearcherDetails(id);


            Console.WriteLine("Name: {0} {1}\nTitle:{2}\nUnit: {3}\nCampus: {4}\nEmail: {5}\n" +
                                  "Photo: {6}\nCurrent job: {7}\nCommenced with institution: {8}\n" +
                                  "Commenced current position: {9}\nPrevious positions: \n",
                                  current_researcher.GivenName, current_researcher.FamilyName, current_researcher.Title, current_researcher.Unit, 
                                  current_researcher.Campus, current_researcher.Email, current_researcher.Photo,
                                  current_researcher.GetCurrentJob().Title(), current_researcher.GetEarliestJob().Start.ToString("dd/MM/yyyy"),
                                  current_researcher.GetCurrentJob().Start.ToString("dd/MM/yyyy"));

            //Test to print all the positions of the researcher (not include student)
            foreach (Position pos in current_researcher.positions)
            {
                if (pos.Level != EmploymentLevel.Student && pos.End != default(DateTime))
                {
                    Console.WriteLine(String.Format("{0}\t{1}\t{2}\n", pos.Start.ToString("dd/MM/yyyy"),
                                                            pos.End.ToString("dd/MM/yyyy"), pos.Title()));
                };
            }
            Console.WriteLine("Tenure: {0}\tPublications: {1}\n", current_researcher.Tenure().ToString("0.0"), 
                                current_researcher.PublicationsCount());
        }
        

        //Test function to print out the details of all researchers
        public void TestResearcherListFull()
        {
            //PublicationsController pubic = new PublicationsController();

            foreach (Researcher x in res)
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


                //pubic.loadPublicationsFor(r);
            }
        }

    }
}
