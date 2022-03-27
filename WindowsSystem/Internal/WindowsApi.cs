using System.Runtime.InteropServices;

namespace HideCursorWhileTyping.WindowsSystem.Internal
{
    internal class WindowsApi
    {
        /// <summary>
        /// <para>
        /// Enables an application to customize the system cursors.
        /// It replaces the contents of the system cursor specified by the id parameter
        /// with the contents of the cursor specified by the hcur parameter and then destroys hcur.
        /// </para>
        /// <para>
        /// The system destroys hcur by calling the DestroyCursor function.
        /// Therefore, hcur cannot be a cursor loaded using the LoadCursor function.
        /// To specify a cursor loaded from a resource, copy the cursor using the CopyCursor function, then pass the copy to SetSystemCursor.
        /// </para>
        /// </summary>
        /// <param name="hcur">
        /// <para>
        /// A handle to the cursor.
        /// The function replaces the contents of the system cursor specified by id with the contents of the cursor handled by hcur.</para>
        /// <para>
        /// The system destroys hcur by calling the DestroyCursor function.
        /// Therefore, hcur cannot be a cursor loaded using the LoadCursor function.
        /// To specify a cursor loaded from a resource, copy the cursor using the CopyCursor function, then pass the copy to SetSystemCursor.
        /// </para>
        /// </param>
        /// <param name="id">The system cursor to replace with the contents of hcur.</param>
        /// <returns>
        /// <para>If the function succeeds, the return value is nonzero.</para>
        /// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport("User32")]
        public static extern bool SetSystemCursor(IntPtr hcur, CursorType id);

        /// <summary>Copies the specified icon from another module to the current module.</summary>
        /// <param name="hIcon">A handle to the icon to be copied.</param>
        /// <returns>
        /// <para>If the function succeeds, the return value is a handle to the duplicate icon.</para>
        /// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport("User32")]
        public static extern IntPtr CopyIcon(IntPtr hIcon);

        /// <summary>
        /// Retrieves or sets the value of one of the system-wide parameters. This function can also update the user profile while setting a parameter.
        /// </summary>
        /// <param name="uiAction">The system-wide parameter to be retrieved or set.</param>
        /// <param name="uiParam">
        /// A parameter whose usage and format depends on the system parameter being queried or set.
        /// For more information about system-wide parameters, see the uiAction parameter.
        /// If not otherwise indicated, you must specify zero for this parameter.
        /// </param>
        /// <param name="pvParam">
        /// A parameter whose usage and format depends on the system parameter being queried or set.
        /// For more information about system-wide parameters, see the uiAction parameter.
        /// If not otherwise indicated, you must specify NULL for this parameter. For information on the PVOID datatype, see Windows Data Types.
        /// </param>
        /// <param name="fWinIni">
        /// If a system parameter is being set, specifies whether the user profile is to be updated,
        /// and if so, whether the WM_SETTINGCHANGE message is to be broadcast to all top-level windows to notify them of the change.
        /// </param>
        /// <returns>
        /// <para>If the function succeeds, the return value is a nonzero value.</para>
        /// <para>If the function fails, the return value is zero.To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport("User32")]
        public static extern bool SystemParametersInfo(SystemParametersInfoAction uiAction, uint uiParam, IntPtr pvParam, UserProfileUpdate fWinIni);
    }
}
