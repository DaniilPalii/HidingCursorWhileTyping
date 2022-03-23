using HideCursorWhileTyping.WindowsSystem.Internal;

namespace HidingCursorWhileTyping.WindowsSystem
{
    internal class WindowsApiWrapper
    {
        public static void SetSystemCursors(Icon cursorIcon)
        {
            foreach (var cursorType in Enum.GetValues<CursorType>())
                SetSystemCursor(cursorType, cursorIcon);
        }

        public static bool ReloadSystemCursors()
            => WindowsApi.SystemParametersInfo(
                SystemParametersInfoAction.ReloadCursors,
                uiParam: 0,
                pvParam: IntPtr.Zero,
                UserProfileUpdate.None);

        private static void SetSystemCursor(CursorType cursorType, Icon cursorIcon)
            => WindowsApi.SetSystemCursor(cursorIcon.Handle, cursorType);
    }
}
