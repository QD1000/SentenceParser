using SentenceParser.Helper;
using SentenceParser.ViewModel;
using System.Windows;

namespace SentenceParser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
           
           Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            var window = new MainWindow() { DataContext = new MainWindowViewModel( new SentenceParserViewModel(new SentenceParserHelper())) };
            window.Show();
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var errorMessage = string.Format("An exception occurred: {0}", e.Exception.Message);
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }

    }
}
