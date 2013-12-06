using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;

namespace s3auto
{
    public class S3Control
    {
        protected XmlDocument doc;
        protected Point main;
        public XmlNode VerifyPos { get; set; }
        public XmlNode position { get; set; }

        public S3Control()
        {
            doc = new XmlDocument();
            doc.Load("Positions.xml");
        }

        public virtual bool Click(int ms = 2000)
        {
            XmlNode node = null;
            if (VerifyPos != null)
                node = VerifyPos;
            else
                node = position;

            int x = Convert.ToInt32(node.Attributes["x"].Value) + main.X;
            int y = Convert.ToInt32(node.Attributes["y"].Value) + main.Y;
            int x2 = Convert.ToInt32(position.Attributes["x"].Value) + main.X;
            int y2 = Convert.ToInt32(position.Attributes["y"].Value) + main.Y;
            //check lvl color changed.
            bool isColorChanged = false;
            Color c1 = WinAPI.GetColor(x, y);
            WinAPI.Click(x2, y2, false, ms);
            Color c2 = WinAPI.GetColor(x, y);
            System.IO.File.AppendAllText("log.txt", string.Format("{0} - {1}", c1.ToString(), c2.ToString()));
            if (!c1.Equals(c2))
                isColorChanged = true;
            return isColorChanged;
        }
    }
}
