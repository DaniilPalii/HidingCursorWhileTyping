using HidingCursorWhileTyping.WindowsSystem;
using System.Windows.Input;
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
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Alt | ModifierKeys.Control | ModifierKeys.Windows))
                return;

            foreach (var key in Keys.Symbolic)
            {
                if (Keyboard.IsKeyDown(key))
                {
                    HideCursor();

                    return;
                }
            }
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
