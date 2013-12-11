using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace s3auto.Controls
{
    public class S3WinArmageddon : S3Window
    {
        protected S3Button buttonNormal = null;
        protected S3Button buttonHard = null;
        protected S3Button buttonAuto = null;
        protected S3Button buttonAutoConfirm = null;

        public S3WinArmageddon(Rectangle parent)
            : base(parent)
        {
            buttonNormal = new S3Button(parent);
            buttonNormal.Name = "";
            buttonHard = new S3Button(parent);
            buttonHard.Name = "";
            buttonAuto = new S3Button(parent);
            buttonAuto.Name = "";
            buttonAutoConfirm = new S3Button(parent);
            buttonAutoConfirm.Name = "";
        }

        public S3Button ButtonNormal
        {
            get
            {
                return buttonNormal;
            }
        }

        public S3Button ButtonHard
        {
            get
            {
                return buttonHard;
            }
        }

        public S3Button ButtonAuto
        {
            get
            {
                return buttonAuto;
            }
        }

        public S3Button ButtonAutoConfirm
        {
            get
            {
                return buttonAutoConfirm;
            }
        }

        public virtual void WaitForComplete()
        {
        }
    }
}
