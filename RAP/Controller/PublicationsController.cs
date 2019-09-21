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

        //public Publication loadBasicPublication(Researcher) 

        //Load all the details for the specific publication
        public void LoadPublicationsFor(Researcher r)
        {
            
            foreach (Publication p in r.publications)
            {
                ERDAdapter.completePublicationDetails(p);
                          
            }
            
        }

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

        public List<Publication> SortPublicationList(Researcher r)
        {
            var sorted_publications = from p in r.publications
                                      orderby p.Year
                                      select p;
            return sorted_publications.ToList();
        }


        //----------------------------------------------------------Test---------------------------------------------------------------

        public void TestPublicationDetails(Researcher r)
        {
            foreach(Publication pub in r.publications)
            {
                //Test to print complete details of a publication
                Console.WriteLine("DOI: {0}\nTitle: {1}\nAuthors: {2}\nPublication year: {3}\nType: {4}\nCite as: {5}\nAvailability date: {6}\n," +
                                  "Age: {7}\n",
                                   pub.DOI, pub.Title, pub.Authors, pub.Year, pub.Type, pub.CiteAs, pub.Available.ToString("dd/MM/yyyy"),
                                   pub.Age());
            }
        }

        public void TestPublicationsCount(Researcher r)
        {
            List<PublicationCount> pc = CumulativePublicationCount(r);
            foreach (var element in pc)
            {
                Console.WriteLine("Year: {0}\nCumulative Publications: {1}", element.PublicYear, element.NumOfPublication);
            }
        }

    }
}
