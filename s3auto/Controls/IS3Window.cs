using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using s3auto.Helper;

namespace s3auto.Controls
{
    public interface IS3Window
    {
        Rectangle Rect { get; }
        string Name { get; set; }
        Point PosVerify { get; }
        Point PosClick { get; }
        Point PosCenter { get; }
        int SleepClick { get; set; }
        bool EnableVerification { get; set; }
        bool Click();
    }
}
