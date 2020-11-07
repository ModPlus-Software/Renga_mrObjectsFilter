namespace mrObjectsFilter.Views
{
    using System.Windows;
    using ViewModels;

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = ModPlusAPI.Language.GetFunctionLocalName(ModPlusConnector.Instance);
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).GetObjectsFromCurrentSelection();
        }

        private void BtCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
