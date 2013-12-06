using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;

namespace s3auto
{
    public class richang : S3Control
    {
        public richang(Point p)
        {
            position = doc.DocumentElement.SelectSingleNode("main/richang");
            VerifyPos = doc.DocumentElement.SelectSingleNode("main/richang/title");
            main = p;
        }

        public class zhenfa : S3Control
        {
            public zhenfa(Point p)
            {
                position = doc.DocumentElement.SelectSingleNode("main/richang/zhenfa");
                main = p;
            }
        }

        public class diandaobagua : S3Control
        {
            public diandaobagua(Point p)
            {
                position = doc.DocumentElement.SelectSingleNode("main/richang/zhenfa/zf[@name='diandaobagua']");
                VerifyPos = doc.DocumentElement.SelectSingleNode("main/richang/title");
                main = p;
            }
        }
    }
    public class Activity
    {

    }
}
