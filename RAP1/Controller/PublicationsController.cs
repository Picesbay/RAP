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

    public class PublicationCount
    {
        public int PublicYear { get; set; }
        public int NumOfPublication { get; set; }
    }
    public class PublicationsController
    {
        //List publications
        private List<Publication> publications = new List<Publication>();

        private ObservableCollection<Publication> viewablePublications;
        public ObservableCollection<Publication> VisiblePublications { get { return viewablePublications; } set { } }


        //List culmulative count

        private ObservableCollection<PublicationCount> viewablePublicationsCount;
        public ObservableCollection<PublicationCount> VisiblePublicationsCount { get { return viewablePublicationsCount; } set { } }


        //Load all the details for the specific publication
        public PublicationsController(Researcher r)
        {
            publications = r.publications;
            viewablePublications = new ObservableCollection<Publication>(publications);
            viewablePublicationsCount = new ObservableCollection<PublicationCount>();
        }

        public Publication LoadPublicationDetails(Publication pub)
        {
            //foreach (Publication p in publications)
            //{
            //    ERDAdapter.completePublicationDetails(p);

            //}
            Publication currPublication = ERDAdapter.completePublicationDetails(pub);
            return currPublication;
        }

        //Load total number of publications by year
        public void CumulativePublicationCount()
        {

            var publication_count = from p in publications
                                    orderby p.Year ascending
                                    group p by p.Year into p_list
                                    select new PublicationCount
                                    {
                                        PublicYear = p_list.First().Year,
                                        NumOfPublication = p_list.Count()
                                    };
            viewablePublicationsCount.Clear();
            publication_count.ToList().ForEach(viewablePublicationsCount.Add);
        }

        public ObservableCollection<PublicationCount> GetCumulativePublicationCount()
        {
            CumulativePublicationCount();
            return VisiblePublicationsCount;
        }

        //Sort the list of publications of a researcher by ascending
        public void SortPublicationList()
        {
            var sorted_publications = from p in publications
                                      
                                      orderby p.Title
                                      orderby p.Year descending
                                      select p;
            viewablePublications.Clear();
            sorted_publications.ToList().ForEach(viewablePublications.Add);
        }


        //---------------------------------------------------Test-------------------------------------------------------------
        //--------------------------------------------Test Function CumulativePublicationCount-------------------------------
        //----------------------------------------------------Start---------------------------------------------------------
        //public void TestPublicationsCount(Researcher r)
        //{
        //    List<PublicationCount> pc = CumulativePublicationCount(r);
        //    Console.WriteLine("{0,-10}  {1}\n", "Year", "Cumulative Publication");
        //    foreach (var element in pc)
        //    {
        //        Console.WriteLine("{0,-10}   {1}\n", element.PublicYear, element.NumOfPublication);
        //    }

        //}
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
                                  "Age:", pub.Age);
            }
        }

        //----------------------------------------------End-------------------------------------------------------------------


    }
}

