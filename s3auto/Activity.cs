using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Threading;

namespace s3auto
{
    public class Activity
    {
        List<KeyValuePair<Thread, Actions>> list = new List<KeyValuePair<Thread, Actions>>();
        public Activity()
        {
            foreach (XmlNode n in Helper.Helper.XMLRoot.SelectNodes("browsers/browser"))
            {
                Actions a = null;
                if (n.Attributes["name"].Value == "firefox")
                    a = new Actions(new Browsers.S3Firefox());
                else if (n.Attributes["name"].Value == "sougou")
                    a = new Actions(new Browsers.S3Firefox());
                else if (n.Attributes["name"].Value == "chrome")
                    a = new Actions(new Browsers.S3Firefox());
                else if (n.Attributes["name"].Value == "opera")
                    a = new Actions(new Browsers.S3Firefox());
                else continue;

                Thread t = new Thread(new ThreadStart(a.DoAll));
                t.Name = "t_" + n.Attributes["name"].Value;
                list.Add(new KeyValuePair<Thread, Actions>(t, a));
            }
        }

        public void RunAll()
        {
            foreach (var kv in list)
            {
                kv.Key.Start();
            }
        }

        public void StopAll()
        {
            foreach (var kv in list)
            {
                kv.Key.Abort();
            }
        }
    }
}
