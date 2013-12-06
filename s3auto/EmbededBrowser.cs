using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace s3auto
{
    public class EmbededBrowser
    {
        private s3auto sa;
        private int leftShift = 0;
        private int topShift = 0;
        private XmlDocument doc;
        private HtmlDocument html;

        public EmbededBrowser(s3auto sa)
        {
            this.sa = sa;
            Init();
        }

        public Rectangle MainRect { get; set; }
        public Rectangle BrowserRect { get; set; }

        public void Init()
        {
            sa.RectangleToScreen(MainRect);
            sa.Browser.RectangleToScreen(BrowserRect);
            leftShift = BrowserRect.Left - MainRect.Left;
            topShift = BrowserRect.Top - MainRect.Top;
            doc = new XmlDocument();
            doc.Load("Positions.xml");
            html = sa.Browser.Document;
            html.Click += new HtmlElementEventHandler(html_Click);
        }

        void html_Click(object sender, HtmlElementEventArgs e)
        {
            if (e.CtrlKeyPressed)
                return;
            
        }
    }
}
