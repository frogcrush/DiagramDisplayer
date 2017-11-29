using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace DiagramDisplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowModel _model = new MainWindowModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _model;

            LoadItems();
            OverGrid.Visibility = Visibility.Collapsed;
        }

        public void LoadItems()
        {
            LoadForFolder("logical", _model.Logical);
            LoadForFolder("development", _model.Development);
            LoadForFolder("physical", _model.Physical);
            LoadForFolder("process", _model.Process);
            LoadForFolder("scenarios", _model.Scenarios);
        }

        public void LoadForFolder(string folderName, ObservableCollection<ImageItem> itemContainer)
        {
            var mainpath = System.IO.Path.Combine(Environment.CurrentDirectory, "models", folderName);
            foreach (var f in new DirectoryInfo(mainpath).GetFiles())
            {
                var l = new ImageItem();
                l.Image = f.FullName;
                l.Title = f.Name;
                itemContainer.Add(l);
            }
        }

        private void ListBox_Selected(object sender, EventArgs e)
        {
            var s = (ListBox)sender;
            if (s.SelectedItem == null) return;         
            _model.SelectedItem = (ImageItem)s.SelectedItem;
            s.SelectedItem = null;
            zoomBorder.Reset();
            OverGrid.Visibility = Visibility.Visible;
        }

        private void CloseGrid(object sender, RoutedEventArgs e)
        {
            OverGrid.Visibility = Visibility.Collapsed;
        }
    }
}
