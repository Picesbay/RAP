using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RAP.Entity;
using RAP.Database;

namespace RAP.Controller
{
    public class PublicationsController
    {
        public Publication loadPublicationsFor(Researcher r)
        {
            Publication pub = new Publication();
            foreach (Publication p in r.publications)
            {
                pub = ERDAdapter.completePublicationDetails(p);

                //Test to print complete details of a publication
                Console.WriteLine("DOI: {0}\nTitle: {1}\nAuthors: {2}\nPublication year: {3}\nType: {4}\nCite as: {5}\nAvailability date: {6}\n\n",
                                   pub.DOI, pub.Title,pub.Authors, pub.Year, pub.Type, pub.CiteAs,pub.Available.ToString("dd/MM/yyyy"));
            }
            return pub;
        }
    }
}
