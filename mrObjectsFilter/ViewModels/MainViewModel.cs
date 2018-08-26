namespace mrObjectsFilter.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Annotations;
    using Models;
    using Renga;

    public class MainViewModel : INotifyPropertyChanged
    {
        private Renga.Application _rengaApp;

        public MainViewModel()
        {
            _rengaApp = new Renga.Application();
        }

        public void GetObjectsFromCurrentSelection()
        {
            var selection = _rengaApp.Selection;
            var objects = _rengaApp.Project.Model.GetObjects();
            _selectedObjectsOnStartup = new List<SelectedObject>();
            int[] selectedObjectsIds = (int[])selection.GetSelectedObjects();
            foreach (int selectedObjectId in selectedObjectsIds)
            {
                if (objects.GetById(selectedObjectId) is IModelObject modelObject)
                {
                    var objectType = modelObject.ObjectType;
                    var selectedObjectModel = _selectedObjectsOnStartup.FirstOrDefault(so => so.CategoryId.Equals(objectType));
                    if (selectedObjectModel != null)
                    {
                        selectedObjectModel.Ids.Add(modelObject.Id);
                    }
                    else
                    {
                        var so = new SelectedObject(GetDisplayNameByObjectType(objectType), objectType);
                        so.Ids.Add(selectedObjectId);
                        _selectedObjectsOnStartup.Add(so);
                    }
                }
            }

            SelectedObjects = new ObservableCollection<SelectedObject>(_selectedObjectsOnStartup);
            OnPropertyChanged(nameof(SelectedObjects));
        }

        private string GetDisplayNameByObjectType(Guid objectType)
        {
            if (objectType == Renga.ObjectTypes.Door) return "Door";
            if (objectType == Renga.ObjectTypes.Window) return "Window";
            if (objectType == Renga.ObjectTypes.Wall) return "Wall";

            return "Other";
        }

        private List<SelectedObject> _selectedObjectsOnStartup;

        public ObservableCollection<SelectedObject> SelectedObjects { get; private set; }

        public int TotalCount => SelectedObjects.Count;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
