namespace mrObjectsFilter
{
    using ModPlus;
    using ModPlusAPI;
    using ViewModels;
    using Views;

    /// <inheritdoc />
    public class PluginStarter : IRengaFunction
    {
        /// <inheritdoc />
        public void Start()
        {
            Statistic.SendCommandStarting(Interface.GetInstance());

            var mainWindow = new MainWindow();
            var mainViewModel = new MainViewModel(mainWindow);
            mainWindow.DataContext = mainViewModel;
            mainWindow.ShowDialog();
            mainViewModel.GetObjectsFromCurrentSelection();
        }
    }
}
