namespace mrObjectsFilter.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Models;
    using ModPlusAPI.Mvvm;
    using Renga;
    using Views;

    public class MainViewModel : VmBase
    {
        private readonly Renga.Application _rengaApplication;
        private readonly MainWindow _mainWindow;
        private List<SelectedObject> _selectedObjectsOnStartup;

        public MainViewModel(MainWindow mainWindow)
        {
            _rengaApplication = new Renga.Application();
            _mainWindow = mainWindow;
            AcceptCommand = new RelayCommand(Accept);
            SelectAllCommand = new RelayCommand(SelectAll);
            SelectNoneCommand = new RelayCommand(SelectNone);
        }

        /// <summary>
        /// Принять и продолжить
        /// </summary>
        public ICommand AcceptCommand { get; set; }

        /// <summary>
        /// Выбрать все пункты в списке
        /// </summary>
        public ICommand SelectAllCommand { get; }

        /// <summary>
        /// Снять выбор со всех пунктов в списке
        /// </summary>
        public ICommand SelectNoneCommand { get; }

        /// <summary>
        /// Коллекция выбранных объектов
        /// </summary>
        public ObservableCollection<SelectedObject> SelectedObjects { get; private set; }

        public int TotalCount
        {
            get
            {
                var c = 0;
                foreach (var selectedObject in SelectedObjects)
                {
                    if (selectedObject.Selected)
                        c += selectedObject.Count;
                }

                return c;
            }
        }
        
        public void GetObjectsFromCurrentSelection()
        {
            var selection = _rengaApplication.Selection;
            var objects = _rengaApplication.Project.Model.GetObjects();
            _selectedObjectsOnStartup = new List<SelectedObject>();
            var selectedObjectsIds = (int[])selection.GetSelectedObjects();
            foreach (var selectedObjectId in selectedObjectsIds)
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
                        so.PropertyChanged += SelectedObject_PropertyChanged;
                        so.Ids.Add(selectedObjectId);
                        _selectedObjectsOnStartup.Add(so);
                    }
                }
            }

            SelectedObjects = new ObservableCollection<SelectedObject>(_selectedObjectsOnStartup);
            OnPropertyChanged(nameof(SelectedObjects));
        }

        private void SelectedObject_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TotalCount));
        }

        private string GetDisplayNameByObjectType(Guid objectType)
        {
            return ModPlus.Helpers.Localization.RengaObjectType(objectType);
        }

        private void Accept(object o)
        {
            var selection = _rengaApplication.Selection;
            var ids = new List<int>();

            foreach (var selectedObject in SelectedObjects)
            {
                if (selectedObject.Selected)
                    ids.AddRange(selectedObject.Ids);
            }

            selection.SetSelectedObjects(ids.ToArray());
            _mainWindow.Close();
        }

        private void SelectAll(object o)
        {
            foreach (var selectedObject in SelectedObjects)
            {
                selectedObject.Selected = true;
            }
        }

        private void SelectNone(object o)
        {
            foreach (var selectedObject in SelectedObjects)
            {
                selectedObject.Selected = false;
            }
        }
    }
}
