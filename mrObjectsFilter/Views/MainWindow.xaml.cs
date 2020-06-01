namespace mrObjectsFilter.Views
{
    using System.Windows;
    using ViewModels;

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = ModPlusAPI.Language.GetFunctionLocalName("mrObjectsFilter", Interface.GetInstance().LName);
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
