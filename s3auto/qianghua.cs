using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;

namespace s3auto
{
    public class qianghua : S3Control
    {
        private zhenjin zj;
        public qianghua(Point p)
        {
            position = doc.DocumentElement.SelectSingleNode("main/lianqi/b");
            zj = new zhenjin(p);
            main = p;
        }

        public void ZJClick()
        {
            zj.Click();
        }

        public void UpdateVPByLvl(string iLev)
        {
            VerifyPos = doc.DocumentElement.SelectSingleNode("main/lianqi/lvl" + iLev); 
        }
    }

    public class zhenjin : S3Control
    {
        public zhenjin(Point p)
        {
            main = p;
            position = doc.DocumentElement.SelectSingleNode("main/lianqi/zj");
        }
    }

    public class QHEventArgs : EventArgs
    {
        private qianghua qh;
        public QHEventArgs(qianghua qh)
        {
            this.qh = qh;
        }
    }
}
