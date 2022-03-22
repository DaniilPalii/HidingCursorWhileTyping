using HideCursorWhileTyping.WindowsSystem.Internal;

namespace HideCursorWhileTyping.Windows
{
    internal class WindowsApiWrapper
    {
        public static void SetSystemCursors(string cursorFileName)
        {
            foreach (var cursorType in Enum.GetValues<CursorType>())
                SetSystemCursor(cursorType, cursorFileName);
        }

        public static bool ReloadSystemCursors()
            => WindowsApi.SystemParametersInfo(
                SystemParametersInfoAction.ReloadCursors,
                uiParam: 0,
                pvParam: IntPtr.Zero,
                UserProfileUpdate.None);

        private static void SetSystemCursor(CursorType cursorType, string cursorFileName)
        {
            var invisibleCursor = WindowsApi.LoadCursorFromFile(cursorFileName);

            WindowsApi.SetSystemCursor(invisibleCursor, cursorType);
        }
    }
}
