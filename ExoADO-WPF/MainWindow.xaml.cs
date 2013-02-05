using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToolBox;

namespace ExoADO_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExploreWindow wExplore;
        private bool connected = false;
        private SqlConnection db;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (!connected)
            {
                Dictionary<string, string> credentials = new Dictionary<string, string>();

                credentials.Add("login", tbLogin.Text);
                credentials.Add("password", pbPassword.Password);

                tbLogin.Text = "";
                pbPassword.Password = "";

                DBConnector dbc = new DBConnector(credentials);
                db = dbc.CreateDBConnect();

                try
                {
                    db.Open();
                    connected = true;
                    if (db.State.ToString().Equals("Open"))
                        lbConnectionStatus.Content = "Online";
                    ConnectionStatusBlock.Background = Brushes.Green;
                    btnConnect.Content = "Disconnect";

                    wExplore = new ExploreWindow();
                    wExplore.Title = "DataBase Reader - Connected as " + dbc.login; 
                    wExplore.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de connection à la DB\n" + ex.Message);
                }
            }
            else
            {
                db.Close();
                connected = false;
                btnConnect.Content = "Connect !";
                if (db.State.ToString().Equals("Closed"))
                    lbConnectionStatus.Content = "Offline";
                ConnectionStatusBlock.Background = Brushes.DarkRed;

                wExplore.Close();
            }
        }
    }
}