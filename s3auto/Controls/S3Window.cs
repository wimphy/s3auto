using System;
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
        private int sleepAfterClick = 2000;
        private bool enableVerification = false;
        private string name = null;
        protected Rectangle parentRect;
        protected Rectangle m_rect;
        private delegate void ClickDel(int x, int y, bool doubleClick, int sleep);
        private List<PointColor> initialColorList = null;

        public S3Window()
        {
        }

        public S3Window(Rectangle parent)
            : this()
        {
            parentRect = parent;
            XmlNode cp = Helper.Helper.XMLRoot.SelectSingleNode(Name + "/Rect");
            m_rect = new Rectangle(cp.GetRect().X + parentRect.X,
                cp.GetRect().Y + parentRect.Y, cp.GetRect().Width, cp.GetRect().Height);
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

        public List<PointColor> GetInitialColors(int cnt = 3)
        {
            if (initialColorList != null && initialColorList.Count > 0)
                return initialColorList;

            initialColorList = new List<PointColor>();

            Random r = new Random();

            for (int i = 0; i < cnt; i++)
            {
                int w = r.Next(RectVerify.Width);
                int h = r.Next(RectVerify.Height);
                initialColorList.Add(new PointColor()
                {
                    p = new Point(parentRect.X + RectVerify.X + w, parentRect.Y + RectVerify.Y + h),
                    c = WinAPI.GetColor(parentRect.X + RectVerify.X + w, parentRect.Y + RectVerify.Y + h)
                });
            }
            return initialColorList;
        }

        public virtual bool Click()
        {
            int x = parentRect.X + PosClick.X;
            int y = parentRect.Y + PosClick.Y;
            if (!EnableVerification)
            {
                WinAPI.Click(x, y, false, SleepClick);
                return true;
            }

            List<PointColor> colorBefore = GetInitialColors();

            WinAPI.Click(x, y, false, SleepClick);
            for (int i = 0; i < colorBefore.Count; i++)
            {
                Color cAfter = WinAPI.GetColor(colorBefore[i].p.X, colorBefore[i].p.Y);
                if (!cAfter.Equals(colorBefore[i].c))
                    return false;
            }
            return true;
        }

        public Point PosCenter
        {
            get
            {
                XmlNode cp = Helper.Helper.XMLRoot.SelectSingleNode(Name + "/CenterPoint");
                return cp.GetPoint();
            }
        }

        //public Rectangle Rect
        //{
        //    get
        //    {
        //        XmlNode cp = root.SelectSingleNode(Name+"/Rect");
        //        m_rect = cp.GetRect();
        //        m_rect = new Rectangle(cp.GetRect().X + this.Rect.X, 
        //            cp.GetRect().Y + this.Rect.Y, cp.GetRect().Width, cp.GetRect().Height);
        //        return m_rect;
        //    }
        //    set
        //    {
        //        m_rect = value;
        //    }
        //}

        public Rectangle RectVerify
        {
            get
            {
                XmlNode cp = Helper.Helper.XMLRoot.SelectSingleNode(Name + "/RectVerify");
                return cp.GetRect();
            }
        }

        public Point PosClick
        {
            get
            {
                XmlNode cp = Helper.Helper.XMLRoot.SelectSingleNode(Name + "/PosClick");
                return cp.GetPoint();
            }
        }


        //public Rectangle ParentRect
        //{
        //    get
        //    {
        //        return parentRect;
        //    }
        //    set
        //    {
        //        parentRect=value;
        //    }
        //}


        //public virtual void Init()
        //{
        //    XmlNode cp = root.SelectSingleNode(Name + "/Rect");
        //    m_rect = new Rectangle(cp.GetRect().X + parentRect.X,
        //        cp.GetRect().Y + parentRect.Y, cp.GetRect().Width, cp.GetRect().Height);
        //}
    }
}
