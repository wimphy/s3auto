using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace s3auto.Helper
{
    public static class Helper
    {
        //Rename doc to class, just to try @class as a varible.
        private static XmlDocument @class = null;
        public static System.Drawing.Point GetPoint(this System.Xml.XmlNode n)
        {
            int x =0;
            int y =0;
            try
            {
                x = Convert.ToInt32(n.Attributes["x"].Value);
                y = Convert.ToInt32(n.Attributes["y"].Value);
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            return new System.Drawing.Point(x, y);
        }

        public static System.Drawing.Rectangle GetRect(this System.Xml.XmlNode n)
        {
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;
            try
            {
                x = Convert.ToInt32(n.Attributes["x"].Value);
                y = Convert.ToInt32(n.Attributes["y"].Value);
                width = Convert.ToInt32(n.Attributes["width"].Value);
                height = Convert.ToInt32(n.Attributes["height"].Value);
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            return new System.Drawing.Rectangle(x, y, width, height);
        }

        public static XmlNode XMLRoot
        {
            get
            {
                return XMLdoc.DocumentElement;
            }
        }

        public static XmlDocument XMLdoc
        {
            get
            {
                if (@class == null)
                {
                    @class = new XmlDocument();
                    @class.Load("Positions.xml");
                }
                return @class;
            }
        }
    }
}
