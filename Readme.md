# Description
Application for Windows that hides cursor while user typing.

# Reason
It is a common situation, especially in browser, when mouse hides typed text from the user.
Windows has an option in control panel to hide the cursor when typing, but it is supported by a very few programs.

# Behavior
The application has only icon in tray to manage it.
When the user presses a key that produces a symbol (like "a", "1" or "!") without modifiers (Ctrl, Alt or Windows key) - the application replaces system cursors with invisible cursor.
When the user move mouse - cursors are restored.

# Technical description
It is .NET 6 WPF application for Windows.
It uses Windows Forms to create a tray icon and Windows API User32.dll to manage the system cursor.

# Alternative solutions
There is AutoHotKey solution - https://github.com/Stefan-Z-Camilleri-zz/Windows-Cursor-Hider.
This solution potentially can have better performance because AutoHotKey has a more complicated way to attach actions to keyboard events.
Suddenly it doesn't support Windows 10 cursors that was changed with "Ease of access" menu. For example, cursor with custom color and size loses image quality after hiding. 

Also, I saw another paid application, but I didn't test it.

