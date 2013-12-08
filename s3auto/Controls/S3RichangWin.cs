using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace s3auto.Controls
{
    public class S3RichangWin : S3Window
    {
        public S3RichangWin(Rectangle parent)
        {
            Name = "main/richang";
            parentRect = parent;
            Init();
        }

        public S3Button Meiri
        {
            get
            {
                S3Button buttonMeiri = new S3Button(parentRect);
                buttonMeiri.Name = "";
                return buttonMeiri;
                //main/warn
            }
        }
    }
}
