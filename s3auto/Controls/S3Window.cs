using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using s3auto.Helper;

namespace s3auto.Controls
{
    public class S3Window : IS3Window
    {
        private static Helper.Logger log;
        private int sleepAfterClick = 2000;
        private bool enableVerification = false;
        private XmlDocument doc = null;
        private XmlElement root = null;

        public S3Window()
        {
            doc.Load("Positions.xml");
            root = doc.DocumentElement;
        }

        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// In ms,default is 2000
        /// </summary>
        public int SleepClick
        {
            get { return sleepAfterClick; }
            set { sleepAfterClick = value; }
        }

        /// <summary>
        /// Set/get whether to verify color changes before/after click.
        /// Default is false
        /// </summary>
        public bool EnableVerification
        {
            get { return enableVerification; }
            set { enableVerification = value; }
        }

        public virtual bool Click()
        {
            bool isColorChanged = false;
            Color c1 = WinAPI.GetColor(PosVerify.X, PosVerify.Y);
            WinAPI.Click(PosClick.X, PosClick.Y, false, SleepClick);
            Color c2 = WinAPI.GetColor(PosVerify.X, PosVerify.Y);
            log.WriteLine("{0} - {1}", c1.ToString(), c2.ToString());
            if (!c1.Equals(c2))
                isColorChanged = true;
            return isColorChanged;
        }

        static public Helper.Logger Log
        {
            get
            {
                if (log == null)
                    return new Helper.Logger();
                return log;
            }
        }


        public Point PosCenter
        {
            get
            {
                XmlNode cp = root.SelectSingleNode(Name);
                return cp.GetPoint();
            }
        }

        public Rectangle Rect
        {
            get { throw new NotImplementedException(); }
        }

        public Point PosVerify
        {
            get { throw new NotImplementedException(); }
        }

        public Point PosClick
        {
            get { throw new NotImplementedException(); }
        }
    }
}
