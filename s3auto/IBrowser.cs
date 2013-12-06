using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace s3auto
{
    public interface IBrowser
    {
        Rectangle rect { get; set; }

        void Init();
    }
}
