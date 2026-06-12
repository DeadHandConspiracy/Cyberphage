using System.Configuration;
using System.Data;
using System.Windows;

namespace Cyberphage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Create and show the splash screen without auto-closing
            SplashScreen splash = new("/Assets/Cyberphage.png");

            // CRITICAL: Set topMost to true to keep it above the MainWindow
            // Set autoClose to false so you control when it disappears
            splash.Show(autoClose: false, topMost: true);

            // Perform your initialization here
            // ...

            // Close the splash screen with a fade-out duration (e.g., 2 seconds)
            splash.Close(TimeSpan.FromSeconds(3));

            base.OnStartup(e);
        }
    }
}