using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RAP.Controller;
using RAP.Entity;
using Application = System.Windows.Application;

namespace RAP.View
{
    public partial class ReportsView : Window
    {
        private ResearcherController rc;
        private const string STAFF_LIST_KEY = "staffList";
        public ReportsView()
        {
            InitializeComponent();
            rc = (ResearcherController)(Application.Current.FindResource(STAFF_LIST_KEY) as ObjectDataProvider).ObjectInstance;
        }

        private void copyEmail_Click(object sender, RoutedEventArgs e)
        {
            var saveEmails = from s in rc.VisibleStaffPerf
                            select s.Email;
            System.Windows.Forms.Clipboard.SetText(string.Join(Environment.NewLine,
                saveEmails.Cast<object>().Select(o => o.ToString())));
        }
    }
}
