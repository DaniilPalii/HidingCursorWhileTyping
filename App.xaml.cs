using HidingCursorWhileTyping.CursorVisibility;
using HidingCursorWhileTyping.UI;
using System.Windows;
using System.Windows.Forms;

namespace HidingCursorWhileTyping
{
    public partial class Application : System.Windows.Application
    {
        public Application()
            => trayIcon = Tray.CreateIcon(onExit: Shutdown);

        protected override void OnStartup(StartupEventArgs e)
            => cursorVisibilityManager.Run();

        protected override void OnExit(ExitEventArgs e)
        {
            cursorVisibilityManager.Stop();

            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            trayIcon.Visible = false;
        }

        private readonly CursorVisibilityManager cursorVisibilityManager = new();
        private readonly NotifyIcon trayIcon;
    }
}
