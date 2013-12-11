using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using s3auto.Controls;

namespace s3auto.Browsers
{
    public class S3Sougou : S3Browser
    {
        public S3Sougou()
            : base("sougou")
        {
            try
            {
                IntPtr h = WinAPI.FindWindow(FwRootCN, null);
                WinAPI.EnumChildWindows(h, EnumProc, new IntPtr(0));
                if (!h.Equals(new IntPtr(0)) && !HWND.Equals(new IntPtr(0)))
                    bExists = true;
            }
            catch (Exception)
            {
                bExists = false;
            }
        }

        public new int TaskbarIndex
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void Minimize()
        {
            base.Minimize();
        }
    }
}
