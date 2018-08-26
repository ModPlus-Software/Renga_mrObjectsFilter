namespace mrObjectsFilter
{
    using System;
    using ModPlus;
    using ViewModels;
    using Views;

    public class PluginStarter : IRengaFunction
    {
        private static MainWindow _mainWindow;
        
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
