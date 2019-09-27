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
using RAP.Entity;

namespace RAP.View
{
   
    public partial class FilterByLevelView : UserControl
    {
        private const string RESEARCHERS_LIST_KEY = "researchersList";
        private ResearcherController rc;

        public FilterByLevelView()
        {
            InitializeComponent();
            rc = (ResearcherController)(Application.Current.FindResource(RESEARCHERS_LIST_KEY) as ObjectDataProvider).ObjectInstance;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
        private void LevelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rc != null)
            {
                string filterComboBox = filterLevelBox.SelectedItem.ToString();
                rc.FilterByLevel(ParseEnum<EmploymentLevel>(filterComboBox));
            }
        }
    }
}
