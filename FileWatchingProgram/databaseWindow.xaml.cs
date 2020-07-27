using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FileWatchingProgram
{
    /// <summary>
    /// Interaction logic for databaseWindow.xaml
    /// </summary>
    public partial class databaseWindow : Window
    {
        private static List<FileEvent> databaseList;
        private static SQLiteConnection sqlite_conn;
        private static SQLiteCommand sqlite_cmd;
        private static SQLiteDataReader sqlite_datareader;
        
        public databaseWindow()
        {
            InitializeComponent();

            databaseList = new List<FileEvent>();

            //Establish the SQLite connection
            sqlite_conn = new SQLiteConnection("Data Source=filewatcher.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();
            
            //create table if it doesn't exist.
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "CREATE TABLE if not exists FileWatch (FileName varchar(20), Extension varchar(6), Path varchar(100), Event varchar(10), DateTime varchar(15));";
            sqlite_cmd.ExecuteNonQuery();
        }
        //----------------------------
        //GUI
        //----------------------------
        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            listLoader("SELECT * FROM FileWatch");
            databaseGrid.ItemsSource = null;
            databaseGrid.ItemsSource = databaseList;
        }
        private void btn_submitQuery_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlite_cmd.CommandText = "SELECT * FROM FileWatch WHERE EXTENSION = @extension";
                sqlite_cmd.Parameters.AddWithValue("@extension", txtbox_Query.Text);
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                sqlite_cmd.CommandText = "SELECT * FROM FileWatch";
                sqlite_cmd.ExecuteNonQuery();

            }

            listLoader(sqlite_cmd.CommandText);
            databaseGrid.ItemsSource = null;
            databaseGrid.ItemsSource = databaseList;
        }
        //----------------------------
        //Methods
        //----------------------------
        private void listLoader(String queryInput)
        {
            
            databaseList = new List<FileEvent>();

            sqlite_cmd.CommandText = queryInput;
            sqlite_datareader = sqlite_cmd.ExecuteReader();
                   
            while (sqlite_datareader.Read())
            {

                FileEvent temp = new FileEvent();

                temp.FileName = sqlite_datareader.GetString(0);
                temp.Extension = sqlite_datareader.GetString(1);
                temp.Path = sqlite_datareader.GetString(2);
                temp.Event = sqlite_datareader.GetString(3);
                temp.DateAndTime = sqlite_datareader.GetString(4);

                databaseList.Add(temp);

            }
            sqlite_datareader.Close();
        }

        //----------------------------
        //Events
        //----------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listLoader("SELECT * FROM FileWatch");
            databaseGrid.ItemsSource = databaseList;
        }
        private void window_db_Closed(object sender, EventArgs e)
        {
            sqlite_conn.Close();
        }
    }
}
