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
        private List<Researcher> res = ERDAdapter.fetchBasicResearcherDetails();
        public void LoadResearchers()
        {
            res.ForEach(x => { Console.WriteLine(String.Format("{0}, {1} ({2})", x.GivenName, x.FamilyName, x.Title)); });
        }

        public void FilterBy(EmploymentLevel level) { }
        public void FilterByName(string name) { }
        public void LoadResearcherDetails() {

            //PublicationsController pubic = new PublicationsController();

            //foreach (Researcher x in res)
            //{
            //    //Load all the details of a researcher
            //    Researcher r = ERDAdapter.completeResearcherDetails(x);

            //    //Test to print the full information
            //    Console.WriteLine("Name: {0} {1}\nTitle:{2}\nUnit: {3}\nCampus: {4}\nEmail: {5}\n" +
            //                      "Photo: {6}\nCurrent job: {7}\nCommenced with institution: {8}\n" +
            //                      "Commenced current position: {9}\nPrevious positions: \n",
            //                      r.GivenName, r.FamilyName, r.Title, r.Unit, r.Campus, r.Email, r.Photo,
            //                      r.GetCurrentJob().Title(), r.GetEarliestJob().Start.ToString("dd/MM/yyyy"),
            //                      r.GetCurrentJob().Start.ToString("dd/MM/yyyy"));

            //    //Test to print all the positions of the researcher (not include student)
            //    foreach (Position pos in r.positions)
            //    {
            //        if (pos.Level != EmploymentLevel.Student)
            //        {
            //            Console.WriteLine(String.Format("{0}\t{1}\t{2}\n", pos.Start.ToString("dd/MM/yyyy"),
            //                                                    pos.End.ToString("dd/MM/yyyy"), pos.Title()));
            //        };
            //    }

            //    //Test to print basic information of publication
            //    Console.WriteLine("Tenure: {0}\tPublications: {1}\n", r.Tenure().ToString("0.0"), r.PublicationsCount());


            //    //pubic.loadPublicationsFor(r);
            //}
            Console.WriteLine("Input ID");
            int id = Int32.Parse(Console.ReadLine());
            Researcher r = ERDAdapter.fetchFullResearcherDetails(id);
            r = ERDAdapter.completeResearcherDetails(r);
            r.publications = ERDAdapter.fetchBasicPublicationDetails(r);
            Console.WriteLine("Name: {0} {1}\nTitle:{2}\nUnit: {3}\nCampus: {4}\nEmail: {5}\n" +
                                  "Photo: {6}\nCurrent job: {7}\nCommenced with institution: {8}\n" +
                                  "Commenced current position: {9}\nPrevious positions: \n",
                                  r.GivenName, r.FamilyName, r.Title, r.Unit, r.Campus, r.Email, r.Photo,
                                  r.GetCurrentJob().Title(), r.GetEarliestJob().Start.ToString("dd/MM/yyyy"),
                                  r.GetCurrentJob().Start.ToString("dd/MM/yyyy"));

            //Test to print all the positions of the researcher (not include student)
            foreach (Position pos in r.positions)
            {
                if (pos.Level != EmploymentLevel.Student && pos.End != default(DateTime))
                {
                    Console.WriteLine(String.Format("{0}\t{1}\t{2}\n", pos.Start.ToString("dd/MM/yyyy"),
                                                            pos.End.ToString("dd/MM/yyyy"), pos.Title()));
                };
            }
            Console.WriteLine("Tenure: {0}\tPublications: {1}\n", r.Tenure().ToString("0.0"), r.PublicationsCount());
        }



    }
}
