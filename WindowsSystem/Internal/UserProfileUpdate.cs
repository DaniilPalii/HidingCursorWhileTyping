namespace HideCursorWhileTyping.WindowsSystem.Internal
{
    [Flags]
    internal enum UserProfileUpdate
    {
        None = 0x00,

        /// <summary>Writes the new system-wide parameter setting to the user profile.</summary>
        IniFileUpdate = 0x01,

        /// <summary>Broadcasts the WM_SETTINGCHANGE message after updating the user profile.</summary>
        ChangeBroadcasting = 0x02
    }
}
