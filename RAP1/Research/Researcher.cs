using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Net;

namespace RAP.Entity
{
    public class Researcher
    {
        public int ID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

        public Position position = new Position();

        public List<Position> positions = new List<Position>();
        public List<Publication> publications = new List<Publication>();

        public Position GetCurrentJob
        {
            get
            {
                Position curr_position = (from p in positions
                                 where p.End == default(DateTime)
                                 select p).SingleOrDefault();
                return curr_position;
            }
        }
        public string CurrentJobTitle
        {
            get { return GetCurrentJob.Title(); }
        }
        public DateTime CurrentJobStart
        {
            get { return GetCurrentJob.Start; }
        }
        public Position GetEarliestJob
        {
            get
            {
                Position first_position = (from p in positions
                                  orderby p.Start
                                  select p).First();
                return first_position;
            }
        }
        public DateTime EarliestStart
        {
            get { return GetEarliestJob.Start; }
        }
        public float Tenure
        {
            get
            {
                float days = (DateTime.Today - GetEarliestJob.Start).Days;
                return days / (365.0f);
            }
        }
        public int PublicationsCount
        {
            get { return publications.Count; }
        }

        public BitmapImage ResearcherPhoto
        {
            get
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"https://www.deviantart.com/pseudolonewolf/art/Generic-Male-Face-295297991", UriKind.Absolute);

                //bi.UriSource = new Uri(Photo, UriKind.Absolute);
                bi.EndInit();

                return bi;
            }
        }

        //public string ResearcherPhoto
        //{
        //    get
        //    {
        //        string remoteUri = @"http://www.americanlayout.com/wp/wp-content/uploads/2012/08/C-To-Go-300x300.png";
        //        string fileName = "Researcher" + ID + ".png";
        //        WebClient webClient = new WebClient();

        //            webClient.DownloadFile(remoteUri, fileName);

        //        return fileName;
        //    }
        //}

        //public Uri ResearcherPhoto
        //{
        //    get
        //    {
        //        Uri photo = new Uri(@"http://www.americanlayout.com/wp/wp-content/uploads/2012/08/C-To-Go-300x300.png");
        //        return photo;
        //    }

        //} 
        public override string ToString()
        {
            return String.Format("{0}, {1} ({2})",GivenName,FamilyName,Title);
        }

    }
}
