namespace mrObjectsFilter.Views
{
    using System.Windows;
    using ViewModels;

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            SizeToContent = SizeToContent.Manual;
            ((MainViewModel)DataContext).GetObjectsFromCurrentSelection();
        }

        private void BtCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
