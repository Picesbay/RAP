using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using RAP.Entity;
using RAP.Controller;

namespace RAP.View
{
    public partial class MainWindow : Window
    {
        private const string RESEARCHERS_LIST_KEY = "researchersList";
        private ResearcherController rc;
        private PublicationsController pc;

        private List<Researcher> researchers;
        private List<Publication> publications;
        private List<Student> students;

        private Researcher researcher;
        private Staff staff;
        public MainWindow()
        {
            InitializeComponent();
            rc = (ResearcherController)(Application.Current.FindResource(RESEARCHERS_LIST_KEY) as ObjectDataProvider).ObjectInstance;
           
        }

        private void researchersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                researcher = (Researcher)e.AddedItems[0];
                researcher = rc.LoadResearcherDetails(researcher);
                ResearcherDetailsPanel.DataContext = researcher;
                //Show past positions
                positionsListView.Items.Clear();
                foreach (var p in researcher.positions)
                {
                    if (researcher.position.Level != EmploymentLevel.Student && p.End != default(DateTime))
                        positionsListView.Items.Add(p.Start + "\t" + p.End + "\t" + p.Title() + Environment.NewLine);
                }

                
                staff = new Staff(researcher);
                rc.GetViewableStudents();
                students = rc.VisibleStudents.ToList();
                if (researcher.position.Level != EmploymentLevel.Student)
                {
                    threeYear.Content = staff.ThreeYearAverage;
                    performance.Content = staff.PerformancePercentage;
                    supervisions.Content = staff.Supervisions;
                }
                else
                {
                    threeYear.Content = null;
                    performance.Content = null;
                    supervisions.Content = null;
                }

                if (researcher.position.Level == EmploymentLevel.Student)
                {
                    Student student = (from s in students
                                   where researcher.ID == s.ID
                                   select s).SingleOrDefault();
                    degree.Content = student.Degree;

                    researchers = rc.VisibleResearchers.ToList();

                    var supervisor = (from s in researchers
                                      where s.ID == student.SupervisorID
                                      select s).SingleOrDefault();
                    supervisors.Content = supervisor.GivenName + " " + supervisor.FamilyName;
                }
                else
                {
                    degree.Content = null;
                    supervisors.Content = null;
                }

                //Show publications
                pc = new PublicationsController(researcher);
                pc.SortPublicationList();
                publications = pc.VisiblePublications.ToList();
                publicationsListView.ItemsSource = publications;
            }
        }
        private void btnPerfReports_Click(object sender, RoutedEventArgs e)
        {
            ReportsView reports = new ReportsView();
            reports.ShowDialog();
        }

        private void btnCumulativeCount_Click(object sender, RoutedEventArgs e)
        {
            if (pc != null)
            {
                CumulativeCount cumulativeCount = new CumulativeCount(pc.GetCumulativePublicationCount().ToList());
                cumulativeCount.Show();
            }
        }

        private void btnShowNames_Click(object sender, RoutedEventArgs e)
        {
            if (pc != null)
            {
                if (researcher.position.Level == EmploymentLevel.Student)
                {
                    var supervisions = from s in students
                                       join r in researchers
                                       on s.ID equals r.ID
                                       where s.SupervisorID == staff.ID
                                       select new Student
                                       {
                                           ID = s.ID,
                                           GivenName = r.GivenName,
                                           FamilyName = r.FamilyName
                                       };
                    SupervisorsName sn = new SupervisorsName(supervisions.ToList());
                    sn.Show();
                }
            }
        }

        private void publicationsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Publication publication;
                publication = (Publication)e.AddedItems[0];
                publication = pc.LoadPublicationDetails(publication);
                PublicationDetailsPanel.DataContext = publication;
            }
        }
    }
}
