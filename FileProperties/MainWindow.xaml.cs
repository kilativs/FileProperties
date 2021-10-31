using System;
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
        private string _currentFolderPath;
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
            var fi = new FileInfo(fileFullName);
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
            var di = new DirectoryInfo(folder);

            if (!di.Exists)
                throw new DirectoryNotFoundException("Папка не найдена :(");
            ClearAllFields();
            TextBoxFolder.Text = di.FullName;
            _currentFolderPath = di.FullName;

            foreach (var d in di.GetDirectories())
                ListBoxFolders.Items.Add(d.Name);

            foreach (var f in di.GetFiles())
                ListBoxFiles.Items.Add(f.Name);
        }

        private void buttonDisplay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var folderPath = TextBoxInput.Text;
                var di = new DirectoryInfo(folderPath);
                if (di.Exists)
                {
                    DisplayFolderList(di.FullName);
                    return;
                }

                var fi = new FileInfo(folderPath);
                if (!fi.Exists) throw new FileNotFoundException("Файл или папка с таким именем не существует");
                if (fi.Directory != null) DisplayFolderList(fi.Directory.FullName);
                var i = ListBoxFiles.Items.IndexOf(fi.Name);
                ListBoxFiles.SelectedIndex = i;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var folderPath = new FileInfo(_currentFolderPath).DirectoryName;
                DisplayFolderList(folderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectionString = ListBoxFiles.SelectedItem.ToString();
                var fullFileName = Path.Combine(_currentFolderPath, selectionString);
                DisplayFileInfo(fullFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxFolders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectionString = ListBoxFolders.SelectedItem.ToString();
                var fullPathName = Path.Combine(_currentFolderPath, selectionString);
                DisplayFolderList(fullPathName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonMove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var filePath = Path.Combine(_currentFolderPath, TextBoxFileName.Text);
                var query = "Действительно переместить файл \n" + filePath + " ?";
                if (MessageBox.Show(query, "Переместить файл?", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    File.Move(filePath, TextBoxNewPath.Text);
                    DisplayFolderList(_currentFolderPath);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Не удается переместить файл из-за исключения: " + exception.Message);
            }
        }

        private void buttonCopy_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}