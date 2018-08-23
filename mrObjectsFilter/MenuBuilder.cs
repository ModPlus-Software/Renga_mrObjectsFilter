using System;
using System.Windows;
using mrObjectsFilter.ViewModels;
using mrObjectsFilter.Views;
using Renga;

namespace mrObjectsFilter
{
    public static class MenuBuilder
    {
        private static ActionEventSource _objectFilterActionEventSource;

        private static MainWindow _mainWindow;

        public static void AddButtonToUiPanel(Renga.Application rengaApp)
        {
            try
            {
                var rengaUi = rengaApp.GetUI();
                var panelExtension = rengaUi.CreateUIPanelExtension();
                var action = rengaUi.CreateAction();
                action.SetToolTip("Objects Filter");
                _objectFilterActionEventSource = new ActionEventSource(action);
                _objectFilterActionEventSource.Triggered += (sender, args) =>
                {
                    
                };
                panelExtension.AddToolButton(action);
                rengaUi.AddExtensionToPrimaryPanel(panelExtension);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + Environment.NewLine + exception.StackTrace, "Objects filter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        public static void AddItemToContextMenu(Renga.Application rengaApp)
        {
            try
            {

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + Environment.NewLine + exception.StackTrace, "Objects filter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void Dispose()
        {
            _objectFilterActionEventSource.Dispose();
        }
    }
}
