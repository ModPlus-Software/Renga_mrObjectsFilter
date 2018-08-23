using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using mrObjectsFilter.Annotations;

namespace mrObjectsFilter.Models
{
    public class SelectedObject : INotifyPropertyChanged
    {
        public SelectedObject(string displayName, Guid categoryId)
        {
            DisplayName = displayName;
            CategoryId = categoryId;
            Ids = new ObservableCollection<int>();
            Ids.CollectionChanged += Ids_CollectionChanged;
        }

        private void Ids_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Count));
        }

        public Guid CategoryId { get; }

        public string DisplayName { get; }

        private bool _selected;

        public bool Selected
        {
            get => _selected;
            set
            {
                if (Equals(value, _selected)) return;
                _selected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<int> Ids { get; }

        public int Count => Ids.Count;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
