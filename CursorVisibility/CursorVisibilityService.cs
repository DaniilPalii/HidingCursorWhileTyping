using HidingCursorWhileTyping.WindowsSystem;
using Cursor = System.Windows.Forms.Cursor;

namespace HidingCursorWhileTyping.CursorVisibility
{
    internal class CursorVisibilityService
    {
        public void UpdateCursorVisibility()
        {
            if (cursorVisible)
                HideCursorIfKeyboardTyping();
            else
                ShowCursorIfMouseMoved();
        }

        public void HideCursor()
        {
            WindowsApiWrapper.SetSystemCursors(Resources.InvisibleCursorIcon);
            cursorVisible = false;
            hiddeningCursorPosition = Cursor.Position;
        }

        public void ShowCursor()
        {
            WindowsApiWrapper.ReloadSystemCursors();
            cursorVisible = true;
        }

        private void HideCursorIfKeyboardTyping()
        {
            if (Keys.CommandModifierKeys.Any(k => k.IsPressed()))
                return;

            if (Keys.Symbolic.Any(k => k.IsPressed()))
                HideCursor();
        }

        private void ShowCursorIfMouseMoved()
        {
            if (Cursor.Position != hiddeningCursorPosition)
                ShowCursor();
        }

        private bool cursorVisible = true;
        private Point hiddeningCursorPosition;
    }
}
