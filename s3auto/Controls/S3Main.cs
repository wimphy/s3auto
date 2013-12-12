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
        private S3WinDailyTask rcw = null;
        private S3WinArmageddon s3WinArmageddon = null;
        private S3WinDungeon s3WinDungeon = null;
        private S3WinCircle s3WinCircle = null;
        private Point offset;
        private S3WinMTower s3WinMTower;
        private S3Button buttonHeroIslandConfirm;
        private S3WinHangup winHangup;

        public S3Main(IntPtr hwnd)
        {
            this.hwnd = hwnd;
            offset = new Point(0, 0);
            rcw = new S3WinDailyTask(Rect);
            s3WinArmageddon = new S3WinArmageddon(Rect);
            s3WinDungeon = new S3WinDungeon(Rect);
            s3WinCircle = new S3WinCircle(Rect);
            s3WinMTower = new S3WinMTower(Rect);
            buttonHeroIslandConfirm = new S3Button(Rect);
            winHangup = new S3WinHangup(Rect);
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

        public S3WinDailyTask RichangWin
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

        public S3WinDungeon WinDungeon
        {
            get
            {
                return s3WinDungeon;
            }
        }

        public S3WinCircle WinCircle
        {
            get
            {
                return s3WinCircle;
            }
        }

        public S3WinMTower WinMTower
        {
            get
            {
                return s3WinMTower;
            }
        }

        public S3WinHangup WinHangup
        {
            get
            {
                return winHangup;
            }
        }
    }
}
