using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RAP.Entity;
using RAP.Database;

namespace RAP.Controller
{

    public struct PublicationCount
    {
        public int PublicYear;
        public int NumOfPublication;
    }
    public class PublicationsController
    {
        //Load all the details for the specific publication
        public void LoadPublicationsFor(Researcher r)
        {
            
            foreach (Publication p in r.publications)
            {
                ERDAdapter.completePublicationDetails(p);
                          
            }
            
        }

        //Load total number of publications by year
        public List<PublicationCount> CumulativePublicationCount(Researcher r)
        {
            
            var publication_count = from p in r.publications
                                    orderby p.Year ascending
                                    group p by p.Year into p_list
                                    select new PublicationCount
                                    {
                                        PublicYear = p_list.First().Year,
                                        NumOfPublication = p_list.Count()
                                    };

            return publication_count.ToList();
        }

        //Sort the list of publications of a researcher by ascending
        public List<Publication> SortPublicationList(Researcher r)
        {
            var sorted_publications = from p in r.publications
                                      orderby p.Year ascending
                                      select p;
            return sorted_publications.ToList();
        }

