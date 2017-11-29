using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramDisplayer
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ImageItem> Logical { get; set; } = new ObservableCollection<ImageItem>();
        public ObservableCollection<ImageItem> Development { get; set; } = new ObservableCollection<ImageItem>();
        public ObservableCollection<ImageItem> Process { get; set; } = new ObservableCollection<ImageItem>();
        public ObservableCollection<ImageItem> Physical { get; set; } = new ObservableCollection<ImageItem>();
        public ObservableCollection<ImageItem> Scenarios { get; set; } = new ObservableCollection<ImageItem>();

        ImageItem _selectedItem;
        public ImageItem SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedItem")); }
        }
    }

    public class ImageItem
    {
        public string Image { get; set; }
        public string Title { get; set; }
    }
}
