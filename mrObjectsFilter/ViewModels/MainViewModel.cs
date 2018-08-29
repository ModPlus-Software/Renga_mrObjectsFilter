namespace mrObjectsFilter.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Models;
    using Renga;

    public class MainViewModel : VmBase
    {
        private readonly Renga.Application _rengaApplication;

        public MainViewModel()
        {
            _rengaApplication = new Renga.Application();
        }

        public void GetObjectsFromCurrentSelection()
        {
            var selection = _rengaApplication.Selection;
            var objects = _rengaApplication.Project.Model.GetObjects();
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
            return ModPlus.Helpers.Localization.RengaObjectType(objectType);
        }

        private List<SelectedObject> _selectedObjectsOnStartup;

        public ObservableCollection<SelectedObject> SelectedObjects { get; private set; }

        public int TotalCount => SelectedObjects.Count;
    }
}
