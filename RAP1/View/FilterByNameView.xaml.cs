using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RAP.Controller;

namespace RAP.View
{
    public partial class FilterByNameView : UserControl
    {
        private const string RESEARCHERS_LIST_KEY = "researchersList";
        private ResearcherController rc;
        public FilterByNameView()
        {
            InitializeComponent();
            rc = (ResearcherController)(Application.Current.FindResource(RESEARCHERS_LIST_KEY) as ObjectDataProvider).ObjectInstance;
        }

        private void FilterNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (rc != null)
            {
                rc.FilterByName(filterNameBox.Text);
            }
        }
    }
}
