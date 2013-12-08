using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace s3auto.Controls
{
    public class S3Main : S3Window
    {
        private IntPtr hwnd;
        private S3RichangWin rcw = null;
        public S3Main(IntPtr hwnd)
        {
            this.hwnd = hwnd;
            rcw = new S3RichangWin(Rect);
            
        }

        public new Rectangle Rect
        {
            get
            {
                WinAPI.Rect rect;
                WinAPI.GetWindowRect(hwnd, out rect);
                return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            }
        }

        public S3RichangWin RichangWin
        {
            get
            {
                return rcw;
            }
        }
    }
}
