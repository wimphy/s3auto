using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace s3auto.Helper
{
    public static class Helper
    {
        public static System.Drawing.Point GetPoint(this System.Xml.XmlNode n, string xName = "x", string yName = "y")
        {
            int x =0;
            int y =0;
            try
            {
                x = Convert.ToInt32(n.Attributes[xName].Value);
                y = Convert.ToInt32(n.Attributes[yName].Value);
            }
            catch (Exception e)
            {
                new Logger().WriteLine(e.Message);
            }
            return new System.Drawing.Point(x, y);
        }
    }
}
