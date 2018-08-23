using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using mrObjectsFilter.Annotations;
using mrObjectsFilter.Models;
using Renga;

namespace mrObjectsFilter.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Renga.Application _rengaApp;

        public MainViewModel()
        {
            _rengaApp = new Renga.Application();
        }

        public void GetObjectsFromCurrentSelection()
        {
            var selection = _rengaApp.GetSelection();
            var objects = _rengaApp.GetProject().GetModel().GetObjects();
            _selectedObjectsOnStartup = new List<SelectedObject>();
            int[] selectedObjectsIds = (int[])selection.GetSelectedModelObjects();
            foreach (int selectedObjectId in selectedObjectsIds)
            {
                if (objects.GetObjectById(selectedObjectId) is IModelObject modelObject)
                {
                    var objectType = modelObject.GetObjectType();
                    var selectedObjectModel = _selectedObjectsOnStartup.FirstOrDefault(so => so.CategoryId.Equals(objectType));
                    if (selectedObjectModel != null)
                        selectedObjectModel.Ids.Add(modelObject.GetId());
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
