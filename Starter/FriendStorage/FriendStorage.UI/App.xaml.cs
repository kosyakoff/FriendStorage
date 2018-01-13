using System.Windows;
using System.Windows.Media.Imaging;
using FriendStorage.UI.View;

namespace FriendStorage.UI
{
  public partial class App : Application
  {
      protected override void OnStartup(StartupEventArgs e)
      {
          base.OnStartup(e);

          MainWindow = new MainWindow();
          MainWindow.Show();
      }
  }
}
