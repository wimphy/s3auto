﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using s3auto.Helper;

namespace s3auto.Controls
{
    public abstract class S3Window : IS3Window
    {
        private static Helper.Logger log;
        private int sleepAfterClick = 2000;
        private bool enableVerification = false;
        private string name = null;
        private Rectangle parentRect;
        private Rectangle m_rect;
        private XmlDocument doc = null;
        private XmlElement root = null;
        private delegate void ClickDel(int x, int y, bool doubleClick, int sleep);

        public S3Window()
        {
            doc = new XmlDocument();
            doc.Load("Positions.xml");
            root = doc.DocumentElement;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
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
            if (!EnableVerification)
            {
                WinAPI.Click(PosClick.X, PosClick.Y, false, SleepClick);
                return true;
            }

            List<int> wList = new List<int>();
            List<int> hList = new List<int>();
            List<Color> colorBefore = new List<Color>();
            Random r = new Random();
            const int cnt = 3;
            for (int i = 0; i < cnt; i++)
            {
                int w = r.Next(RectVerify.Width);
                int h = r.Next(RectVerify.Height);
                wList.Add(w);
                hList.Add(h);
                colorBefore.Add(WinAPI.GetColor(RectVerify.X + w, RectVerify.Y + h));
            }

            WinAPI.Click(PosClick.X, PosClick.Y, false, SleepClick);
            for (int i = 0; i < cnt; i++)
            {
                Color cAfter = WinAPI.GetColor(RectVerify.X + wList[i], RectVerify.Y + hList[i]);
                if (!cAfter.Equals(colorBefore[i]))
                    return false;
            }
            return true;
        }

        public static Helper.Logger Log
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
                XmlNode cp = root.SelectSingleNode(Name+"/CenterPoint");
                return cp.GetPoint();
            }
        }

        public Rectangle Rect
        {
            get
            {
                XmlNode cp = root.SelectSingleNode(Name+"/Rect");
                m_rect = cp.GetRect();
                m_rect = new Rectangle(cp.GetRect().X + this.Rect.X, 
                    cp.GetRect().Y + this.Rect.Y, cp.GetRect().Width, cp.GetRect().Height);
                return m_rect;
            }
            set
            {
                m_rect = value;
            }
        }

        public Rectangle RectVerify
        {
            get
            {
                XmlNode cp = root.SelectSingleNode(Name + "/RectVerify");
                return cp.GetRect();
            }
        }

        public Point PosClick
        {
            get
            {
                XmlNode cp = root.SelectSingleNode(Name + "/PosClick");
                return cp.GetPoint();
            }
        }


        public Rectangle ParentRect
        {
            get
            {
                return parentRect;
            }
            set
            {
                parentRect=value;
            }
        }
    }
}
