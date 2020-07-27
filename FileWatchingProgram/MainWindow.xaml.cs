
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileWatchingProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private String userDirectory;
        private String userExtension;
        private FileSystemWatcher watcher;
        private Thread fileWatchThread = null;

        private static List<FileEvent> dataStorage;
        private static DateTime dateTime;
        private static SQLiteConnection sqlite_conn;
        private static SQLiteCommand sqlite_cmd;
        public MainWindow()
        {
            dateTime = DateTime.UtcNow;
            dataStorage = new List<FileEvent>();


            InitializeComponent();

            //Register the directory input text box to check for when the user adds text to the textbox
            //The reason for this is the accept button will be disabled until text is added.
            this.txtbox_DirectoryInput.TextChanged += Txtbox_DirectoryInput_TextChanged;


        }

        //----------------------------
        //GUI Items
        //----------------------------
            
        //Menu Items------------------------------------------------------
        private void mnuitm_File_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuitm_Start_Click(object sender, RoutedEventArgs e)
        {

            this.fileWatchThread = new Thread(new ThreadStart(this.startRun));
            this.fileWatchThread.Start();

            //Update the GUI
            dataGrid.ItemsSource = null;
            this.txtbox_DirectoryInput.IsEnabled = false;
            this.txtbox_ExtensionInput.IsEnabled = false;
            this.btn_Apply.IsEnabled = false;

            this.btn_Stop.IsEnabled = true;
            this.btn_Start.IsEnabled = false;
            this.btn_commit.IsEnabled = false;
            this.tlbr_startbtn.IsEnabled = false;
            this.tlbr_stopbtn.IsEnabled = true;

            if (this.userExtension.Equals(""))
            {
                this.txtblk_Status.Text = "Watching directory: " + this.userDirectory;
            }
            else
            {
                this.txtblk_Status.Text = "Watching directory: " + this.userDirectory + "    with extension: " + this.userExtension;
            }
        }

        private void mnuitm_Stop_Click(object sender, RoutedEventArgs e)
        {
            //Stop the watcher
            watcher.EnableRaisingEvents = false;

            //Update the GUI
            dataGrid.ItemsSource = dataStorage;
            this.txtbox_DirectoryInput.IsEnabled = true;
            this.txtbox_ExtensionInput.IsEnabled = true;
            this.btn_Apply.IsEnabled = true;
            
            this.btn_Stop.IsEnabled = false;
            this.btn_Start.IsEnabled = true;
            this.btn_commit.IsEnabled = true;
            this.tlbr_startbtn.IsEnabled = true;
            this.tlbr_stopbtn.IsEnabled = false;

            this.txtblk_Status.Text = "Stopped current watch. Press 'Start' to continue or enter new input.";
        }
        private void btn_commit_Click(object sender, RoutedEventArgs e)
        {
            commitResults();

        }
        private void mnuitm_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mnuitm_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuitm_Help_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuitm_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Unnamed File Watching Program\n\n Made by Morgan Combs 07/2020");

        }

        private void mnuitm_Shortcuts_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("File Menu:     alt + F\n" +
                            "Edit Menu:     alt + E\n" +
                            "Help Menu:     alt + H\n" +
                            "Exit:          alt + X");
        }
        private void tlbr_exitbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void tlbr_OpenDatabase_Click(object sender, RoutedEventArgs e)
        {

            databaseWindow database = new databaseWindow();
            database.Show();
        }
        //Buttons------------------------------------------------
        private void btn_Apply_Click(object sender, RoutedEventArgs e)
        {
            //Save the strings
            this.userDirectory = this.txtbox_DirectoryInput.Text;
            this.userExtension = this.txtbox_ExtensionInput.Text;
            
            if(!this.userExtension.Equals(""))
            {
                this.userExtension = String.Concat("*", this.userExtension);
            }
            //If the user input directory is valid
            if(verifyDirectory())
            {
                //Update the GUI
                this.txtbox_DirectoryInput.Clear();
                this.txtbox_ExtensionInput.Clear();

                this.btn_Apply.IsEnabled = false;

                this.btn_Start.IsEnabled = true;
                this.btn_Stop.IsEnabled = false;
                this.btn_commit.IsEnabled = false;

                //Update the status string
                if (this.userExtension.Equals(""))
                {
                    this.txtblk_Status.Text = "Ready to watch directory: " + this.userDirectory;
                }
                else
                {
                    this.txtblk_Status.Text = "Ready to watch directory: " + this.userDirectory + "      with extension: " + this.userExtension;
                }
            }
            //if not valid
            else
            {
                this.userDirectory = "";
                this.userExtension = "";

                this.txtblk_Status.Text = "Cannot find directory.";
            }

        }
        //ListView-----------------------------------------------
        private void populateListView()
        {
            foreach(FileEvent i in dataStorage)
            {
                GridViewColumn fileName = new GridViewColumn();
            }
        }
        //----------------------------
        //Methods
        //----------------------------
        private bool verifyDirectory()
        {
            if(Directory.Exists(this.userDirectory))
            {
                return true;
            }
            return false;
        }
        private void startRun()
        {
            Run();
        }
        private async void Run()
        {
            using (watcher = new FileSystemWatcher())
            {

                watcher.Path = this.userDirectory;

                watcher.Filter = this.userExtension;

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                // Add event handlers.
                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.IncludeSubdirectories = true;

                //Start watching
                watcher.EnableRaisingEvents = true;

                while (true);
            }
        }
        private void commitResults()
        {
            //Establish the SQLite connection
            sqlite_conn = new SQLiteConnection("Data Source=filewatcher.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();

            //create table if it doesn't exist.
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "CREATE TABLE if not exists FileWatch (FileName varchar(20), Extension varchar(6), Path varchar(100), Event varchar(10), DateTime varchar(15));";
            sqlite_cmd.ExecuteNonQuery();

            foreach (FileEvent i in dataStorage)
            {
                sqlite_cmd.CommandText = @"INSERT INTO FileWatch VALUES ($FileName, $Extension, $Path, $Event, $DateTime)";

                String fileName = i.FileName;
                String extension = i.Extension;
                String fullPath = i.Path;
                String changeType = i.Event;

                sqlite_cmd.Parameters.AddWithValue("$FileName", fileName);
                sqlite_cmd.Parameters.AddWithValue("$Extension", extension);
                sqlite_cmd.Parameters.AddWithValue("$Path", fullPath);
                sqlite_cmd.Parameters.AddWithValue("$Event", changeType);
                sqlite_cmd.Parameters.AddWithValue("$DateTime", dateTime.ToString());

                sqlite_cmd.ExecuteNonQuery();
            }
            //close the connection
            sqlite_conn.Close();

            dataStorage.Clear();

            //Update the GUI
            dataGrid.ItemsSource = null;
            dataStorage = new List<FileEvent>();
            this.btn_commit.IsEnabled = false;
        }
        private static string FileRemover(String toSplit)
        {
            //removes the file from the path and returns it
            int lastSlash = toSplit.LastIndexOf("\\");
            return toSplit.Substring(lastSlash + 1);
        }
        private static string PathRemover(String toSplit)
        {
            //removes the path from the string and returns it
            int lastSlash = toSplit.LastIndexOf("\\");
            return toSplit.Substring(0, lastSlash);
        }
        private static string ExtensionRemover(String toSplit)
        {
            int lastPeriod = toSplit.LastIndexOf(".");

            if(lastPeriod <= 0)
            {
                return "";
            }
            return toSplit.Substring(lastPeriod);
        }
        //----------------------------
        //Events
        //----------------------------
        private void Txtbox_DirectoryInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.btn_Apply.IsEnabled = true;
            
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            FileEvent toAdd = new FileEvent();

            toAdd.FileName = FileRemover(e.FullPath);
            toAdd.Extension = ExtensionRemover(e.FullPath);
            toAdd.Path = PathRemover(e.FullPath);
            toAdd.Event = e.ChangeType.ToString();
            toAdd.DateAndTime = dateTime.ToString();

            dataStorage.Add(toAdd);
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            FileEvent toAdd = new FileEvent();

            toAdd.FileName = FileRemover(e.FullPath);
            toAdd.Extension = ExtensionRemover(e.FullPath);
            toAdd.Path = PathRemover(e.FullPath);
            toAdd.Event = e.ChangeType.ToString();
            toAdd.DateAndTime = dateTime.ToString();

            dataStorage.Add(toAdd);
        }

        private void dataGrid_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            dataGrid.ItemsSource = dataStorage;
        }

  

        private void window_main_Closing(object sender, CancelEventArgs e)
        {
            ExitWindow exit = new ExitWindow();
            exit.ShowDialog();

            if(exit.commit == true)
            {
                commitResults();
            }
            Environment.Exit(0);
        }
    }
}
