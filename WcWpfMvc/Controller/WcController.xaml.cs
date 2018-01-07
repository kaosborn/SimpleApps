// SimpleApps / WcWpfMvc / WcController.xaml.cs
//
// This file was renamed from MainWindow.xaml.cs and moved from the project root.
// This class owns the message pump and model and processes all input from the user.
// 

using System.Windows;
using AppModel;

namespace AppController
{
    public interface IWcViewFactory
    {
        void Create (WcController controller, WcModelBind modelBind);
    }

    public partial class WcController : Window
    {
        private string[] args;
        private IWcViewFactory viewFactory;
        private WcModel wcModel;

        public WcController (string[] args, IWcViewFactory viewFactory)
        {
            this.args = args;
            this.viewFactory = viewFactory;
            InitializeComponent();
        }

        private void WcController_Loaded (object sender, RoutedEventArgs e)
        {
            // Best practice is to create the model here - after the app has started.
            // This allows showing splash or status while model is spinning up.
            wcModel = new WcModel();
            viewFactory.Create (this, wcModel.Bind);
            DataContext = wcModel.Bind;

            // Process command line arguments:
            inputBox.Text = string.Join (" ", args);
        }

        private void WcController_Click (object sender, RoutedEventArgs ea)
        {
            if (! string.IsNullOrWhiteSpace (inputBox.Text))
                wcModel.Parse (inputBox.Text);
            inputBox.Clear();
        }
    }
}
