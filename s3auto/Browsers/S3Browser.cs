using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using s3auto.Controls;
using System.Drawing;

namespace s3auto.Browsers
{
    public abstract class S3Browser : IBrowser
    {
        protected string flashWinClassName = null;
        protected IntPtr flashHwnd;
        protected string browserClassName = null;

        public WinAPI.Rect Rect
        {
            get
            {
                WinAPI.Rect rect;
                WinAPI.GetWindowRect(HWND, out rect);
                return rect;
            }
        }

        public string ClassName
        {
            get
            {
                StringBuilder sb = new StringBuilder(200);
                WinAPI.GetClassName(HWND, sb, 200);
                return sb.ToString();
            }
        }

        public IntPtr HWND
        {
            get { return WinAPI.FindWindow(browserClassName, null); }
        }

        public void Activate()
        {
            WinAPI.SwitchToThisWindow(HWND, true);
        }

        public virtual void Minimize()
        {
            throw new NotImplementedException();
        }


        public int TaskbarIndex
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public S3Main FlashWin
        {
            get
            {
                return new S3Main(flashHwnd);
            }
        }


        public virtual bool EnumProc(IntPtr hwnd, IntPtr lParam)
        {
            StringBuilder sb = new StringBuilder(200);

            WinAPI.GetClassName(hwnd, sb, 200);
            if (flashWinClassName == sb.ToString())
            {
                flashHwnd = hwnd;
                return false;
            }
            //sb.Clear();
            return true;
        }
    }
}
