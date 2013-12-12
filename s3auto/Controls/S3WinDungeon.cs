using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace s3auto.Controls
{
    public class S3WinDungeon : S3Window
    {
        private S3Button buttonAuto;
        private S3Button buttonAutoConfirm;
        private S3Button buttonStop;
        private S3Button buttonStopConfirm;
        private S3Button buttonRollStart;
        private S3Button buttonRoll;
        public S3WinDungeon(Rectangle parent)
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
            buttonRollStart = new S3Button(parent);
            buttonRollStart.Name = "";
            buttonRoll = new S3Button(parent);
            buttonRoll.Name = "" + new Random().Next(5);
            buttonStop = new S3Button(parent);
            buttonStop.Name = "";
            buttonStopConfirm = new S3Button(parent);
            buttonStopConfirm.Name = "";
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

        public S3Button ButtonStop
        {
            get
            {
                return buttonStop;
            }
        }

        public S3Button ButtonStopConfirm
        {
            get
            {
                return buttonStopConfirm;
            }
        }

        public S3Button ButtonRollStart
        {
            get
            {
                System.Threading.Thread.Sleep(10000);
                return buttonRollStart;
            }
        }

        public S3Button ButtonRoll
        {
            get
            {
                return buttonRoll;
            }
        }
    }
}
