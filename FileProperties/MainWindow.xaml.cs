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