// This file was generated as App.xaml.cs in the project root.
//

using System.Windows;
using AppController;
using AppModel;

namespace AppView
{
    public class WcViewFactory : IWcViewFactory
    {
        public void Create (WcController controller, WcModelBind modelBind)
        {
            var _ = new WcView (controller, modelBind);
        }
    }

    public partial class App : Application
    {
        // Adding this override in order to inject a view factory
        // into a MainWindow constructor overload.
        protected override void OnStartup (StartupEventArgs supArgs)
        {
            base.OnStartup (supArgs);
            MainWindow = new WcController (supArgs.Args, new WcViewFactory());
            MainWindow.Show();
        }
    }

    public class WcView
    {
        private WcController controller;
        private WcModelBind modelBind;

        public WcView (WcController controller, WcModelBind modelBind)
        {
            this.controller = controller;
            this.modelBind = modelBind;
        }
    }
}
