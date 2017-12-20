using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Vlad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.InitializeList();
        }

        private string MainDirectoryPath = "C:\\Test";

        private void InitializeList()
        {
            path.Text = MainDirectoryPath;
            InitializeL1();
        }

        public void AddAllDirectoriesInListBox(ListBox lb, string targetDirectory)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            int index = 0;
            foreach (var directory in subdirectoryEntries.Select(directory => new DirectoryInfo(directory)))
            {
                lb.Items.Insert(index++, directory.Name);
            }
        }

        private string GetL1DirectoryPath()
        {
            return path.Text;
        }

        private string GetL2DirectoryPath()
        {
            return string.Format("{0}\\{1}", this.GetL1DirectoryPath(), l1.SelectedValue);
        }

        private string GetL3DirectoryPath()
        {
            return string.Format("{0}\\{1}", this.GetL2DirectoryPath(), l2.SelectedValue);
        }

        private string GetL4DirectoryPath()
        {
            return string.Format("{0}\\{1}", this.GetL3DirectoryPath(), l3.SelectedValue);
        }

        private void l1_Selected(object sender, RoutedEventArgs e)
        {
            l2.Items.Clear();
            l3.Items.Clear();
            l4.Items.Clear();
            this.AddAllDirectoriesInListBox(l2, this.GetL2DirectoryPath());
        }

        private void l2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            l3.Items.Clear();
            l4.Items.Clear();
            this.AddAllDirectoriesInListBox(l3, this.GetL3DirectoryPath());
        }

        private void l3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            l4.Items.Clear();
            this.AddAllDirectoriesInListBox(l4, this.GetL4DirectoryPath());
        }
        
        private void InitializeL1()
        {
            l1.Items.Clear();
            l2.Items.Clear();
            l3.Items.Clear();
            l4.Items.Clear();
            this.AddAllDirectoriesInListBox(l1, this.GetL1DirectoryPath());
        }

        private void path_LostFocus(object sender, RoutedEventArgs e)
        {
            InitializeL1();
        }
    }
}
