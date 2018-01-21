// This file plus it's .xaml file were originally generated as MainWindow
// in the project root.
//

using System;
using System.Windows;
using System.Windows.Controls;
using AppModel;
using AppViewModel;

namespace AppView
{
    public partial class WcWindow : Window
    {
        public WcWindow()
        {
            InitializeComponent();
        }

        // This is deemed acceptable code-behind because it is application startup.
        private void WcController_Loaded (object sender, RoutedEventArgs e)
        {
            WcPresenter presenter;

            // Best practice is to create the model here - after the app has started.
            // This allows showing splash or status while model is spinning up.
            var model = new WcModel();

            // DataContext can be created in XAML but only with the default constructor.
            DataContext = presenter = new WcPresenter (model);

            // Process command line arguments:
            presenter.InputLine = string.Join (" ", Environment.GetCommandLineArgs());
        }
    }
}
