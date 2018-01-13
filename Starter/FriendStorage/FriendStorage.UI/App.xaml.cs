using System.Windows;
using Autofac;
using FriendStorage.UI.Startup;
using FriendStorage.UI.View;

namespace FriendStorage.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootsStrapper = new BootsStrapper();
            var container = bootsStrapper.BootStrap();
            MainWindow = container.Resolve<MainWindow>();
            MainWindow.Show();
        }
    }
}