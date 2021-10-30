using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FileProperties
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string currentFolderPath;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearAllFields()
        {
            ListBoxFolders.Items.Clear();
            ListBoxFiles.Items.Clear();
            TextBoxFolder.Text = "";
            TextBoxFileName.Text = "";
            TextBoxCreationTime.Text = "";
            TextBoxLastAccessTime.Text = "";
            TextBoxLastWriteTime.Text = "";
            TextBoxFileSize.Text = "";
        }

        private void DisplayFileInfo(string fileFullName)
        {
            FileInfo fi = new FileInfo(fileFullName);
            if (!fi.Exists)
            {
                throw new FileNotFoundException("Файл "+fileFullName+" не найден :(");
            }
            TextBoxFileName.Text = fi.Name;
            TextBoxFileSize.Text = (fi.Length / 1024).ToString() + " kb";
            TextBoxCreationTime.Text = fi.CreationTime.ToLongTimeString();
            TextBoxLastAccessTime.Text = fi.LastAccessTime.ToLongTimeString();
            TextBoxLastWriteTime.Text = fi.LastWriteTime.ToLongTimeString();
        }
        
        private void DisplayFolderList(string folder)
        {
            DirectoryInfo di = new DirectoryInfo(folder);

            if (!di.Exists)
                throw new DirectoryNotFoundException("Папка не найдена :(");
            ClearAllFields();
            TextBoxFolder.Text = di.FullName;
            currentFolderPath = di.FullName;

            foreach (DirectoryInfo d in di.GetDirectories())
                ListBoxFolders.Items.Add(d.Name);

            foreach (FileInfo f in di.GetFiles())
                ListBoxFiles.Items.Add(f.Name);
        }

        private void buttonDisplay_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void buttonUp_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void listBoxFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void listBoxFolders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}