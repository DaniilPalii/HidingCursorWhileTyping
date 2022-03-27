﻿namespace HideCursorWhileTyping.WindowsSystem.Internal
{
    enum CursorType : uint
    {
        /// <summary>Standard arrow and small hourglass.</summary>
        AppStarting = 32650,

        /// <summary>Standard arrow.</summary>
        Normal = 32512,

        /// <summary>Crosshair.</summary>
        Cross = 32515,

        /// <summary>Windows 2000/XP: Hand.</summary>
        Hand = 32649,

        /// <summary>Arrow and question mark.</summary>
        Help = 32651,

        /// <summary>I-beam.</summary>
        IBeam = 32513,

        /// <summary>Slashed circle.</summary>
        No = 32648,

        /// <summary>Four-pointed arrow pointing north, south, east, and west.</summary>
        SizeAll = 32646,

        /// <summary>Double-pointed arrow pointing northeast and southwest.</summary>
        SizeNESW = 32643,

        /// <summary>Double-pointed arrow pointing north and south.</summary>
        SizeNS = 32645,

        /// <summary>Double-pointed arrow pointing northwest and southeast.</summary>
        SizeNWSE = 32642,

        /// <summary>Double-pointed arrow pointing west and east.</summary>
        SizeWE = 32644,

        /// <summary>Vertical arrow.</summary>
        Up = 32516,

        /// <summary>Hourglass.</summary>
        Wait = 32514
    }
}
