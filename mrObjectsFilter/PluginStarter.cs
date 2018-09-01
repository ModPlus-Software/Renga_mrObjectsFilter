namespace mrObjectsFilter
{
    using ModPlus;
    using ModPlusAPI;
    using ViewModels;
    using Views;

    public class PluginStarter : IRengaFunction
    {
        public void Start()
        {
            Statistic.SendCommandStarting(Interface.GetInstance());

            var mainWindow = new MainWindow();
            MainViewModel mainViewModel = new MainViewModel(mainWindow);
            mainWindow.DataContext = mainViewModel;
            mainWindow.ShowDialog();
            mainViewModel.GetObjectsFromCurrentSelection();
        }
    }
}
