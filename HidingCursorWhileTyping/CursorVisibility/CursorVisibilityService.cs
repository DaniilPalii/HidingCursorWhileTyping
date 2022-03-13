using HideCursorWhileTyping.Windows;
using System.IO;
using System.Windows.Input;
using Cursor = System.Windows.Forms.Cursor;

namespace HidingCursorWhileTyping.CursorVisibility
{
    internal class CursorVisibilityService
    {
        public CursorVisibilityService()
        {
            if (!invisibleCursorFile.Exists)
                throw new FileNotFoundException(message: null, fileName: invisibleCursorFile.FullName);
        }

        public void UpdateCursorVisibility()
        {
            if (cursorVisible)
                HideCursorIfKeyboardTyping();
            else
                ShowCursorIfMouseMoved();
        }

        public void HideCursor()
        {
            WindowsApiWrapper.SetSystemCursors(invisibleCursorFile.FullName);
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

            foreach (var key in ListenedKeys)
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
        private readonly FileInfo invisibleCursorFile = new(@"Resources\InvisibleCursor.cur");

        private static readonly IEnumerable<Key> ListenedKeys = new Key[]
        {
            Key.A,
            Key.B,
            Key.C,
            Key.D,
            Key.E,
            Key.F,
            Key.G,
            Key.H,
            Key.I,
            Key.J,
            Key.K,
            Key.L,
            Key.M,
            Key.N,
            Key.O,
            Key.P,
            Key.Q,
            Key.R,
            Key.S,
            Key.T,
            Key.U,
            Key.V,
            Key.W,
            Key.X,
            Key.Y,
            Key.Z,
            Key.D1,
            Key.D2,
            Key.D3,
            Key.D4,
            Key.D5,
            Key.D6,
            Key.D7,
            Key.D8,
            Key.D9,
            Key.D0,
            Key.OemTilde,
            Key.CapsLock,
            Key.OemMinus,
            Key.OemPlus,
            Key.OemBackslash,
            Key.OemOpenBrackets,
            Key.OemCloseBrackets,
            Key.OemSemicolon,
            Key.OemQuotes,
            Key.OemPipe,
            Key.OemComma,
            Key.OemPeriod,
            Key.OemQuestion,
            Key.Divide,
            Key.Multiply,
            Key.Subtract,
            Key.Add,
            Key.Separator,
        };
    }
}
