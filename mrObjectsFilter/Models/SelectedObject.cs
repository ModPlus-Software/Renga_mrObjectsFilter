namespace mrObjectsFilter.Models
{
    using System;
    using System.Collections.ObjectModel;
    using ModPlusAPI.Mvvm;

    public class SelectedObject : VmBase
    {
        private bool _selected = true;

        public SelectedObject(string displayName, Guid categoryId)
        {
            DisplayName = displayName;
            CategoryId = categoryId;
            Ids = new ObservableCollection<int>();
            Ids.CollectionChanged += Ids_CollectionChanged;
        }
        
        public Guid CategoryId { get; }

        public string DisplayName { get; }
        
        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<int> Ids { get; }

        public int Count => Ids.Count;

        private void Ids_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Count));
        }
    }
}
