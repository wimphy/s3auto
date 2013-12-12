using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace s3auto.Controls
{
    public class S3WinMTower:S3Window
    {
        private S3Button buttonAutoConfirm;
        private S3Button buttonAuto;
        public S3WinMTower(Rectangle parent)
            : base(parent)
        {
            //buttonNormal = new S3Button(parent);
            //buttonNormal.Name = "";
            //buttonHard = new S3Button(parent);
            //buttonHard.Name = "";
            buttonAuto = new S3Button(parent);
            buttonAuto.Name = "";
            buttonAutoConfirm = new S3Button(parent);
            buttonAutoConfirm.Name = "";
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


        internal void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
