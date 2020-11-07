namespace mrObjectsFilter
{
    using ModPlus;
    using ViewModels;
    using Views;

    /// <inheritdoc />
    public class PluginStarter : IRengaFunction
    {
        /// <inheritdoc />
        public void Start()
        {
#if !DEBUG
            ModPlusAPI.Statistic.SendCommandStarting(ModPlusConnector.Instance);
#endif

            var mainWindow = new MainWindow();
            var mainViewModel = new MainViewModel(mainWindow);
            mainWindow.DataContext = mainViewModel;
            mainWindow.ShowDialog();
            mainViewModel.GetObjectsFromCurrentSelection();
        }
    }
}
