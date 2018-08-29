namespace mrObjectsFilter
{
    using ModPlus;
    using ViewModels;
    using Views;

    public class PluginStarter : IRengaFunction
    {

        public void Start()
        {
            MainViewModel mainViewModel = new MainViewModel();
            var mainWindow = new MainWindow { DataContext = mainViewModel };
            mainWindow.ShowDialog();
            mainViewModel.GetObjectsFromCurrentSelection();
        }
    }
}
