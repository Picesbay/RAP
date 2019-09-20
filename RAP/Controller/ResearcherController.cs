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
        //    res.ForEach(x =>
        //    {
        //        Researcher r = ERDAdapter.completeResearcherDetails(x);
        //        Console.WriteLine("Name: {0} {1}\nTitle:{2}\nUnit: {3}\nCampus: {4}\nEmail: {5}\n" +
        //                          "Photo: {6}", r.GivenName, r.FamilyName, r.Title, r.Unit, r.Campus, r.Email, r.Photo);

        //        Console.WriteLine("Current job: {0}\nCommenced with institution: {1}\n" +
        //                              "Commenced current position: {2}\n" +
        //                              "Previous positions: \n", r.GetCurrentJob().Title(),
        //                              r.GetEarliestJob().Start,
        //                               r.GetCurrentJob().Start);
        //        r.positions.ForEach(pos =>
        //        {
        //            if (pos.Level != EmploymentLevel.Student)
        //            {
        //                Console.WriteLine(String.Format("{0}\t{1}\t{2}\n",
        //                pos.Start, pos.End, pos.Title()));
        //            };
        //        });
        //});

            foreach(Researcher x in res)
            {
                Researcher r = ERDAdapter.completeResearcherDetails(x);
                Console.WriteLine("Name: {0} {1}\nTitle:{2}\nUnit: {3}\nCampus: {4}\nEmail: {5}\n" +
                                  "Photo: {6}Current job: {7}\nCommenced with institution: {8}\n" +
                                  "Commenced current position: {9}\nPrevious positions: \n", 
                                  r.GivenName, r.FamilyName, r.Title, r.Unit, r.Campus, r.Email, r.Photo, 
                                  r.GetCurrentJob().Title(), r.GetEarliestJob().Start, r.GetCurrentJob().Start);

            }
        }

       
        
    }
}
