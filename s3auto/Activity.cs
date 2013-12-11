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
        List<KeyValuePair<string, Actions>> list = new List<KeyValuePair<string, Actions>>();
        public Activity()
        {
            foreach (XmlNode n in Helper.Helper.XMLRoot.SelectNodes("browsers/browser"))
            {
                if (n.Attributes["name"].Value == "firefox")
                {
                    list.Add(new KeyValuePair<string, Actions>(n.Attributes["name"].Value,
                        new Actions(new Browsers.S3Firefox())));
                }

                if (n.Attributes["name"].Value == "sougou")
                {
                    list.Add(new KeyValuePair<string, Actions>(n.Attributes["name"].Value,
                          new Actions(new Browsers.S3Sougou())));
                }

                if (n.Attributes["name"].Value == "chrome")
                {
                    list.Add(new KeyValuePair<string, Actions>(n.Attributes["name"].Value,
                          new Actions(new Browsers.S3Chrome())));
                }

                if (n.Attributes["name"].Value == "opera")
                {
                    list.Add(new KeyValuePair<string, Actions>(n.Attributes["name"].Value,
                          new Actions(new Browsers.S3Opera())));
                }
            }
        }

        public void RunAll()
        {
            foreach (var kv in list)
            {
                kv.Value.Run();
            }
        }

        public void StopAll()
        {
            foreach (var kv in list)
            {
                kv.Value.Stop();
            }
        }
    }
}
