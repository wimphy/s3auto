using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using s3auto.Controls;

namespace s3auto.Browsers
{
    public class S3Firefox : S3Browser
    {
        public S3Firefox()
        {
            flashWinClassName = "NativeWindowClass";
            browserClassName = "SE_SogouExplorerFrame";
            IntPtr h = WinAPI.FindWindow("SE_AxControl", null);
            WinAPI.EnumChildWindows(h, EnumProc, new IntPtr(0));
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
