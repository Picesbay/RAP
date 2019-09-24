﻿using System;
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
using RAP.Entity;
using RAP.Controller;

namespace RAP.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ResearcherListView : UserControl
    {
        private ResearcherController rc;

        private const string RESEARCHERS_LIST_KEY = "researchersList";
        
        private const string FILTER_LEVEL_KEY = "employmentLevel";
        public ResearcherListView()
        {
            InitializeComponent();
            rc = (ResearcherController)(Application.Current.FindResource(RESEARCHERS_LIST_KEY) as ObjectDataProvider).ObjectInstance;

        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
        private void levelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(rc != null)
            {
                string filterComboBox = filterLevelBox.SelectedItem.ToString();
                rc.FilterByLevel(ParseEnum<EmploymentLevel>(filterComboBox));
                //EmploymentLevel pos = (EmploymentLevel)(Application.Current.FindResource(FILTER_LEVEL_KEY) as ObjectDataProvider).ObjectInstance;
                //rc.FilterByLevel(pos);
                //researchersListBox.DataContext = rc.GetViewableList();
                //MessageBox.Show();
            }
           

        }

        private void FilterNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
