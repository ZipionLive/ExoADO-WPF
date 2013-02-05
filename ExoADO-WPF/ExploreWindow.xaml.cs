using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToolBox;

namespace ExoADO_WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ExploreWindow : Window
    {
        public ExploreWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DBSearch.gender gender;
            DBSearch.status status;

            if (rbMan.IsChecked == true)
                gender = DBSearch.gender.male;
            else if (rbWoman.IsChecked == true)
                gender = DBSearch.gender.female;
            else
                gender = DBSearch.gender.both;

            if (rbSingle.IsChecked == true)
                status = DBSearch.status.single;
            else if (rbMarried.IsChecked == true)
                status = DBSearch.status.married;
            else
                status = DBSearch.status.both;

            DBSearch dbs = new DBSearch(cbCol.SelectedValue.ToString(), tbSearchTerm.Text, status, gender);
            MessageBox.Show(string.Format("{0}\n{1}\n{2}\n{3}", dbs.queryField, dbs.queryTerm, dbs.queryGender.ToString(), dbs.queryStatus.ToString()));
        }
    }
}
