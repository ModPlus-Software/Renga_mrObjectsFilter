using System;
using mrObjectsFilter.ViewModels;
using mrObjectsFilter.Views;
using ModPlus;
using Renga;

namespace mrObjectsFilter
{
    public class PluginStarter : IRengaFunction
    {
        private static MainWindow _mainWindow;

        public bool Initialize(string pluginFolder)
        {
            var rengaApp = new Renga.Application();
            MenuBuilder.AddButtonToUiPanel(rengaApp);
            return true;
        }

        public void Stop()
        {
            MenuBuilder.Dispose();
        }

        public void Start()
        {
            if (_mainWindow == null)
            {
                MainViewModel mainViewModel = new MainViewModel();
                _mainWindow = new MainWindow();
                _mainWindow.DataContext = mainViewModel;
                _mainWindow.Closed += MainWindow_Closed;
                _mainWindow.Show();
                mainViewModel.GetObjectsFromCurrentSelection();
            }
            else
            {
                _mainWindow.Activate();
                _mainWindow.Focus();
            }
        }

        private static void MainWindow_Closed(object sender, EventArgs e)
        {
            _mainWindow = null;
        }
    }
}
