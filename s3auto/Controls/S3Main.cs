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
        private WinS3DailyTask rcw = null;
        private S3WinArmageddon s3WinArmageddon = null;
        private Point offset;

        public S3Main(IntPtr hwnd)
        {
            this.hwnd = hwnd;
            offset = new Point(0, 0);
            rcw = new WinS3DailyTask(Rect);
            s3WinArmageddon = new S3WinArmageddon(Rect);
        }

        public Rectangle Rect
        {
            get
            {
                WinAPI.Rect rect;
                WinAPI.GetWindowRect(hwnd, out rect);
                return new Rectangle(rect.Left + Offset.X, rect.Top + Offset.Y,
                    rect.Right - rect.Left, rect.Bottom - rect.Top);
            }
        }

        public Point Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        public WinS3DailyTask RichangWin
        {
            get
            {
                return rcw;
            }
        }

        public S3WinArmageddon WinArmageddon
        {
            get
            {
                return s3WinArmageddon;
            }
        }
    }
}
