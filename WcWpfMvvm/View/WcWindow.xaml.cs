// This file plus it's .xaml file were originally generated as MainWindow
// in the project root.
//

using System;
using System.Windows;
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

        // MVVM purists say this file should contain no code-behind.
        // However these application startup bits seem necessary here:
        // - Spin up the model before the GUI for splash & status.
        // - Initialize DataContext with an argument.
        // - Process command line arguments.
        private void WcController_Loaded (object sender, RoutedEventArgs e)
        {
            WcPresenter presenter;

            // Best practice is to create the model here - after the app has started.
            // This allows showing splash or status while model is spinning up.
            var model = new WcModel();

            // Initialize DataContext here because it can't be created in XAML with an argument.
            DataContext = presenter = new WcPresenter (model);

            // Process command line arguments:
            presenter.InputLine = string.Join (" ", Environment.GetCommandLineArgs());
        }
    }
}
