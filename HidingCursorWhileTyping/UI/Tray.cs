using System.Windows.Forms;

namespace HidingCursorWhileTyping.UI
{
    internal static class Tray
    {
        public static NotifyIcon CreateIcon(Action onExit)
            => new()
            {
                Icon = Resources.ApplicationIcon,
                Text = Resources.ApplicationTitle,
                ContextMenuStrip = new()
                {
                    Items = { new ToolStripMenuItem(Resources.ExitTitle, image: null, onClick: (_, __) => onExit()) }
                },
                Visible = true,
            };
    }
}
