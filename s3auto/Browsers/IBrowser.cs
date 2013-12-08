using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using s3auto.Controls;

namespace s3auto.Browsers
{
    public interface IBrowser
    {
        WinAPI.Rect Rect { get; }
        string ClassName { get; }
        IntPtr HWND { get; }
        int TaskbarIndex { get; }
        S3Main FlashWin { get; }
        void Activate();
        void Minimize();
        bool EnumProc(IntPtr hwnd, IntPtr lParam);
    }
}
