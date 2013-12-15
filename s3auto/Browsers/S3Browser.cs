using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using s3auto.Controls;
using System.Drawing;
using System.Xml;

namespace s3auto.Browsers
{
    public abstract class S3Browser : IBrowser
    {
        private string browserName = null;
        private IntPtr flashHwnd;
        protected bool bExists = false;
        protected const string LockFlag = "LockFlag";

        public S3Browser(string name)
        {
            browserName = name;
        }

        public WinAPI.Rect Rect
        {
            get
            {
                WinAPI.Rect rect;
                WinAPI.GetWindowRect(HWND, out rect);
                return rect;
            }
        }

        public bool Idle { get; set; }

        public string ClassName
        {
            get
            {
                XmlNode n = Helper.Helper.XMLRoot.SelectSingleNode(
                    string.Format("browsers/browser[@name='{0}']/@className", browserName));
                return n.Value;
            }
        }

        public string FwClassName
        {
            get
            {
                XmlNode n = Helper.Helper.XMLRoot.SelectSingleNode(
                    string.Format("browsers/browser[@name='{0}']/@flashWinClassName", browserName));
                return n.Value;
            }
        }

        public string FwRootCN
        {
            get
            {
                XmlNode n = Helper.Helper.XMLRoot.SelectSingleNode(
                    string.Format("browsers/browser[@name='{0}']/@flashWinRootClassName", browserName));
                return n.Value;
            }
        }

        public IntPtr HWND
        {
            get { return WinAPI.FindWindow(ClassName, null); }
        }

        public void Activate()
        {
            lock (LockFlag)
            {
                WinAPI.SwitchToThisWindow(HWND, true);
            }
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

        public bool Exists
        {
            get
            {
                return bExists;
            }
        }

        public S3Main FlashWin
        {
            get
            {
                S3Main m = new S3Main(flashHwnd);
                return m;
            }
        }


        public virtual bool EnumProc(IntPtr hwnd, IntPtr lParam)
        {
            StringBuilder sb = new StringBuilder(200);

            WinAPI.GetClassName(hwnd, sb, 200);
            if (FwClassName == sb.ToString())
            {
                flashHwnd = hwnd;
                return false;
            }
            //sb.Clear();
            return true;
        }
    }
}
