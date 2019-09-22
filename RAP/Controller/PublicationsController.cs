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


        //---------------------------------------------------Test-------------------------------------------------------------
        //--------------------------------------------Test Function CumulativePublicationCount-------------------------------
        //----------------------------------------------------Start---------------------------------------------------------
        public void TestPublicationsCount(Researcher r)
        {
            List<PublicationCount> pc = CumulativePublicationCount(r);
            Console.WriteLine("{0,-10}  {1}\n", "Year", "Cumulative Publication");
            foreach(var element in pc)
            {
                Console.WriteLine("{0,-10}   {1}\n",element.PublicYear,element.NumOfPublication);
            }

        }
        //----------------------------------------------------End---------------------------------------------------------------



        //---------------------------------------Test publication details-----------------------------------------------------
        //----------------------------------------------Start-----------------------------------------------------------------
        public void TestPublicationDetails(Researcher r)
        {
            foreach (Publication pub in r.publications)
            {
                //Test to print complete details of a publication
                Console.WriteLine("{0,-20} {1,-20}\n{2,-20} {3,-20}\n{4,-20} {5,-20}\n{6,-20} {7,-20}\n{8,-20} {9,-20}\n{10,-20} {11,-20}\n" +
                                  "{12,-20} {13,-20}\n{14,-20} {15,-20}\n", "DOI:", pub.DOI, "Title:", pub.Title,
                                  "Author:", pub.Authors, "Publication year:", pub.Year, "Type:", pub.Type,
                                  "Cite as:", pub.CiteAs, "Availability date:", pub.Available.ToString("dd /MM/yyyy"),
                                  "Age:", pub.Age());
            }
        }

        //----------------------------------------------End-------------------------------------------------------------------


    }
}

