using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using s3auto.Browsers;

namespace s3auto
{
    public partial class s3auto : Form
    {
        private Thread thread1;
        private static bool bF = false;
        private HtmlDocument doc;
        bool clickStart = false;
        private Form2 f2;
        private qianghua qh;
        private System.Timers.Timer t1;
        public s3auto()
        {
            InitializeComponent();
            webBrowser1.Navigate("http://web.3366.com/s3");
            f2 = new Form2();
            t1 = new System.Timers.Timer();
            t1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
            t1.Interval = 3000;
        }

        public WebBrowser Browser { get { return webBrowser1; } }


        public bool EnumProc(IntPtr hwnd, IntPtr lParam)
        {
            StringBuilder sb = new StringBuilder(200);

            WinAPI.GetClassName(hwnd, sb, 200);
            if ("NativeWindowClass" == sb.ToString())
            {
                WinAPI.Rect rect;
                WinAPI.ClientToScreen(hwnd, out rect);
                return false;
            }
            //sb.Clear();
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            S3Firefox ff = new S3Firefox();
            ff.Activate();
            System.Threading.Thread.Sleep(2000);
            ff.FlashWin.RichangWin.Click();

            IntPtr h = WinAPI.FindWindow("SE_AxControl", null);
            WinAPI.EnumChildWindows(h, EnumProc, new IntPtr(0));

            thread1 = new Thread(Start);
            string command = comboBox1.Text;
            if (checkBox1.Checked)
                command += "|" + "juezhanzhidi";
            if (checkBox2.Checked)
                command += "|" + "fuben";
            if (checkBox3.Checked)
                command += "|" + "zhenfa";
            if (checkBox4.Checked)
                command += "|" + "fenjie";
            thread1.Start(command);
        }

        public static void Start(object args)
        {
            List<string> argList = args.ToString().Split('|').ToList<string>();
            IntPtr wnd = FindGameWin(argList[0]);
            WinAPI.Rect rect = new WinAPI.Rect();
            WinAPI.GetWindowRect(wnd, out rect);
            XmlDocument doc = new XmlDocument();
            doc.Load("Positions.xml");

            if (argList.Contains("fenjie"))
                bF = true;

            int times = 1;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                times += 1;
            if (!argList.Contains("juezhanzhidi"))
                times = 0;
            for (int i = 0; i < times; i++)
                JueZhanZhiDi(doc.DocumentElement, rect);

            times = 2;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                times += 2;
            if (!argList.Contains("fuben"))
                times = 0;
            for (int i = 0; i < times; i++)
                Fuben(doc.DocumentElement, rect);

            times = 2;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                times += 2;
            if (!argList.Contains("zhenfa"))
                times = 0;
            for (int i = 0; i < times; i++)
                ZhenFa(doc.DocumentElement, rect);

            //End
            Guaji(doc.DocumentElement, rect, true);
        }

        public static IntPtr FindGameWin(string className)
        {
            IntPtr wnd = WinAPI.FindWindow(className, null);
            WinAPI.SwitchToThisWindow(wnd, true);
            Thread.Sleep(2000);
            wnd = WinAPI.FindWindowEx(wnd, IntPtr.Zero, "SeWnd", null);
            wnd = WinAPI.FindWindowEx(wnd, IntPtr.Zero, "XWnd", null);
            wnd = WinAPI.FindWindowEx(wnd, IntPtr.Zero, "Container", null);
            wnd = WinAPI.FindWindowEx(wnd, IntPtr.Zero, "Shell Embedding", null);
            wnd = WinAPI.FindWindowEx(wnd, IntPtr.Zero, "Shell DocObject View", null);
            wnd = WinAPI.FindWindowEx(wnd, IntPtr.Zero, "Internet Explorer_Server", null);
            wnd = WinAPI.FindWindowEx(wnd, IntPtr.Zero, "MacromediaFlashPlayerActiveX", null);
            return wnd;
        }

        public static IntPtr FindGameWinQQGame(string className)
        {
            string cn = "TXIE_{E472094C-802D-42BB-8765-22528826EF3C}";
            IntPtr wnd = WinAPI.FindWindow(className, null);
            WinAPI.SwitchToThisWindow(wnd, true);
            Thread.Sleep(2000);
            wnd = WinAPI.FindWindowEx(wnd, IntPtr.Zero, "AtlAxWin90", null);
            wnd = WinAPI.FindWindowEx(wnd, IntPtr.Zero, "Shell Embedding", null);
            wnd = WinAPI.FindWindowEx(wnd, IntPtr.Zero, "Shell DocObject View", null);
            wnd = WinAPI.FindWindowEx(wnd, IntPtr.Zero, "Internet Explorer_Server", null);
            wnd = WinAPI.FindWindowEx(wnd, IntPtr.Zero, "MacromediaFlashPlayerActiveX", null);
            return wnd;
        }

        public static void Guaji(XmlElement root, WinAPI.Rect rect, bool isEnd = false)
        {
            if (bF)
                FenJie(rect);

            XmlNode n = root.SelectSingleNode("main/richang");
            int x = rect.Left + Convert.ToInt32(n.Attributes[0].Value);
            int y = rect.Top + Convert.ToInt32(n.Attributes[1].Value);
            WinAPI.Click(x, y);

            n = n.SelectSingleNode("meiri");
            x = rect.Left + Convert.ToInt32(n.Attributes[0].Value);
            y = rect.Top + Convert.ToInt32(n.Attributes[1].Value);
            WinAPI.Click(x, y);

            n = n.SelectSingleNode("guaji");
            x = rect.Left + Convert.ToInt32(n.Attributes[0].Value);
            y = rect.Top + Convert.ToInt32(n.Attributes[1].Value);
            WinAPI.Click(x, y);

            if (isEnd)
            {
                WinAPI.Click(rect.Left + 320, rect.Top + 300);
                WinAPI.Click(rect.Left + 456, rect.Top + 351);
            }
        }

        public static void WaitForFightSenarioEnd(WinAPI.Rect rect, int timeout = 60)
        {                 //done
            int x = rect.Left + 525;
            int y = rect.Top + 250;
            for (int i = 0; i < timeout; i++)
            {
                Color c4 = WinAPI.GetColor(x, y);
                Color c5 = WinAPI.GetColor(rect.Left + 387, rect.Top + 175);
                Color c6 = WinAPI.GetColor(rect.Left + 650, rect.Top + 180);
                Thread.Sleep(5000);
                if (((int)c4.R < 50 && (int)c4.G < 50 && (int)c4.B < 50)
                    && (int)c5.R < 50 && (int)c5.G < 50 && (int)c5.B < 50
                    && (int)c6.R < 50 && (int)c6.G < 50 && (int)c6.B < 50)
                {
                    WinAPI.Click(x, y);
                    break;
                }
            }
        }

        public static void FenJie(WinAPI.Rect rect)
        {
            //lianqi
            WinAPI.Click(rect.Left + 501, rect.Top + 543, false, 3000);
            //zhuangbeifenjie
            WinAPI.Click(rect.Left + 367, rect.Top + 134);
            //color
            WinAPI.Click(rect.Left + 461, rect.Top + 176);
            //green
            WinAPI.Click(rect.Left + 461, rect.Top + 236);
            //select all
            WinAPI.Click(rect.Left + 530, rect.Top + 176);
            //color
            WinAPI.Click(rect.Left + 461, rect.Top + 176);
            //blue
            WinAPI.Click(rect.Left + 461, rect.Top + 256);
            //select all
            WinAPI.Click(rect.Left + 530, rect.Top + 176);
            //fenjie
            WinAPI.Click(rect.Left + 700, rect.Top + 378);
        }

        public static bool Fight(WinAPI.Rect rect, int x, int y, int seconds = 5)
        {
            bool bFight = false;
            Color c5 = WinAPI.GetColor(rect.Left + 658, rect.Top + 32);
            Color c6 = WinAPI.GetColor(rect.Left + 680, rect.Top + 30);
            Color c51 = WinAPI.GetColor(rect.Left + 86, rect.Top + 131);
            Color c61 = WinAPI.GetColor(rect.Left + 86, rect.Top + 232);
            WinAPI.Click(rect.Left + x, rect.Top + y, false, 0);
            for (int i = 0; i < seconds; i++)
            {
                Thread.Sleep(1000);
                Color c7 = WinAPI.GetColor(rect.Left + 658, rect.Top + 32);
                Color c8 = WinAPI.GetColor(rect.Left + 680, rect.Top + 30);
                Color c52 = WinAPI.GetColor(rect.Left + 86, rect.Top + 131);
                Color c62 = WinAPI.GetColor(rect.Left + 86, rect.Top + 232);
                if (c5.ToString() != c7.ToString()
                    && c6.ToString() != c8.ToString()
                    && c51.ToString() != c52.ToString()
                    && c61.ToString() != c62.ToString())
                {
                    bFight = true;
                    break;
                }
            }
            return bFight;
        }

        public static void JueZhanZhiDi(XmlElement root, WinAPI.Rect rect)
        {
            Guaji(root, rect);

            XmlNode n = root.SelectSingleNode("main/richang");
            int x = rect.Left + Convert.ToInt32(n.Attributes[0].Value);
            int y = rect.Top + Convert.ToInt32(n.Attributes[1].Value);
            WinAPI.Click(x, y);

            n = n.SelectSingleNode("juezhan");
            x = rect.Left + Convert.ToInt32(n.Attributes[0].Value);
            y = rect.Top + Convert.ToInt32(n.Attributes[1].Value);
            WinAPI.Click(x, y);


            foreach (XmlNode n1 in n.ChildNodes)
            {
                //Thread.Sleep(1000);
                x = rect.Left + 500;
                y = rect.Top + 180;
                Color c1 = WinAPI.GetColor(x, y);

                //chuan song
                x = rect.Left + Convert.ToInt32(n1.Attributes[0].Value);
                y = rect.Top + Convert.ToInt32(n1.Attributes[1].Value);
                WinAPI.Click(x, y);

                //confirm yes, if guaji
                x = rect.Left + 500;
                y = rect.Top + 180;
                Color c2 = WinAPI.GetColor(x, y);
                if (c1.ToString() != c2.ToString())
                {
                    x = rect.Left + 475;
                    y = rect.Top + 215;
                    WinAPI.Click(x, y);
                    break;
                }
            }

            //if started but not finish, then continue
            Color c5 = WinAPI.GetColor(rect.Left + 750, rect.Top + 425);
            if (!((int)c5.R < 50 && (int)c5.G < 50 && (int)c5.B < 50))
            {
                //jin ru
                x = rect.Left + 532;
                y = rect.Top + 468;
                WinAPI.Click(x, y);
            }

            for (int i = 0; i < 50; i++)
            {
                //kai shi
                bool bFight = Fight(rect, 360, 475);
                if (!bFight)
                    continue;
                WaitForFightSenarioEnd(rect);
            }
        }

        public static void Fuben(XmlElement root, WinAPI.Rect rect)
        {
            Guaji(root, rect);

            XmlNode n = root.SelectSingleNode("main/richang");
            int x = rect.Left + Convert.ToInt32(n.Attributes[0].Value);
            int y = rect.Top + Convert.ToInt32(n.Attributes[1].Value);
            WinAPI.Click(x, y);

            n = n.SelectSingleNode("fuben");
            x = rect.Left + Convert.ToInt32(n.Attributes[0].Value);
            y = rect.Top + Convert.ToInt32(n.Attributes[1].Value);
            WinAPI.Click(x, y);


            foreach (XmlNode n1 in n.ChildNodes)
            {
                //Thread.Sleep(1000);
                x = rect.Left + 500;
                y = rect.Top + 180;
                Color c1 = WinAPI.GetColor(x, y);

                //chuan song
                x = rect.Left + Convert.ToInt32(n1.Attributes[0].Value);
                y = rect.Top + Convert.ToInt32(n1.Attributes[1].Value);
                WinAPI.Click(x, y);

                //confirm yes, if guaji
                x = rect.Left + 500;
                y = rect.Top + 180;
                Color c2 = WinAPI.GetColor(x, y);
                if (c1.ToString() != c2.ToString())
                {
                    x = rect.Left + 475;
                    y = rect.Top + 215;
                    WinAPI.Click(x, y);
                    n = n1;
                    break;
                }
            }

            //begin
            WinAPI.Click(rect.Left + 700, rect.Top + 200);

            //fight
            foreach (XmlNode n1 in n.ChildNodes)
            {
                x = Convert.ToInt32(n1.Attributes[0].Value);
                y = Convert.ToInt32(n1.Attributes[1].Value);
                bool bFight = Fight(rect, x, y);
                if (!bFight)
                    continue;
                WaitForFightSenarioEnd(rect);
            }
        }

        public static void ZhenFa(XmlElement root, WinAPI.Rect rect)
        {
            Guaji(root, rect);

            XmlNode n = root.SelectSingleNode("main/richang");
            int x = rect.Left + Convert.ToInt32(n.Attributes[0].Value);
            int y = rect.Top + Convert.ToInt32(n.Attributes[1].Value);
            WinAPI.Click(x, y);

            n = n.SelectSingleNode("zhenfa");
            x = rect.Left + Convert.ToInt32(n.Attributes[0].Value);
            y = rect.Top + Convert.ToInt32(n.Attributes[1].Value);
            WinAPI.Click(x, y);


            foreach (XmlNode n1 in n.ChildNodes)
            {
                //Thread.Sleep(1000);
                x = rect.Left + 500;
                y = rect.Top + 180;
                Color c1 = WinAPI.GetColor(x, y);

                //chuan song
                x = rect.Left + Convert.ToInt32(n1.Attributes[0].Value);
                y = rect.Top + Convert.ToInt32(n1.Attributes[1].Value);
                WinAPI.Click(x, y);

                //confirm yes, if guaji
                x = rect.Left + 500;
                y = rect.Top + 180;
                Color c2 = WinAPI.GetColor(x, y);
                if (c1.ToString() != c2.ToString())
                {
                    x = rect.Left + 475;
                    y = rect.Top + 215;
                    WinAPI.Click(x, y);
                    n = n1;
                    break;
                }
            }

            //begin
            WinAPI.Click(rect.Left + 530, rect.Top + 420);

            //fight
            foreach (XmlNode n1 in n.ChildNodes)
            {
                x = Convert.ToInt32(n1.Attributes[0].Value);
                y = Convert.ToInt32(n1.Attributes[1].Value);
                bool bFight = Fight(rect, x, y);
                if (!bFight)
                    continue;
                WaitForFightSenarioEnd(rect);
            }
        }

        public static void Login(WinAPI.Rect rect)
        {             //WinAPI.Click(rect.Left + 782, rect.Top + 25);
            WinAPI.Click(rect.Left + 140, rect.Top + 405);
            WinAPI.Click(rect.Left + 635, rect.Top + 253);
            WinAPI.Click(rect.Left + 540, rect.Top + 340, true);
            WinAPI.KeyPress("2805628355");
            WinAPI.Click(rect.Left + 520, rect.Top + 400);
            WinAPI.KeyPress("@@def456");
            WinAPI.Click(rect.Left + 450, rect.Top + 460);
            WinAPI.Click(rect.Left + 700, rect.Top + 430);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (thread1 != null)
                thread1.Abort();
            t1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rectangle wbRect = new Rectangle();
            wbRect = this.webBrowser1.RectangleToScreen(this.webBrowser1.ClientRectangle);

            Point p = new Point();
            p.X = wbRect.Left;
            p.Y = wbRect.Top;

            qh = new qianghua(p);
            qh.UpdateVPByLvl(textBoxLev.Text);
            qh.ZJClick();
            t1.Start();
        }

        void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            clickStart = qh.Click();
            if (clickStart)
                t1.Stop();
        }

        private void s3auto_KeyDown(object sender, KeyEventArgs e)
        {
            //Point p = new Point();
            //WinAPI.GetCursorPos(out p);
            //MessageBox.Show("x:" + p.X + "y:" + p.Y + " " + WinAPI.GetColor(p.X, p.Y).ToString());
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            //Point p = new Point();
            //WinAPI.GetCursorPos(out p);
            //MessageBox.Show("x:" + p.X + "y:" + p.Y + " " + WinAPI.GetColor(p.X, p.Y).ToString());
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < 400; i++)
                WinAPI.mouse_event(WinAPI.MOUSEEVENTF_LEFTDOWN | WinAPI.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            doc = webBrowser1.Document;
            doc.Click += new HtmlElementEventHandler(doc_Click);
            textBoxAddress.Text = webBrowser1.Url.ToString();
        }

        void doc_Click(object sender, HtmlElementEventArgs e)
        {
            if (e.CtrlKeyPressed)
                clickStart = false;
            if (e.ShiftKeyPressed)
                GenPos();
        }

        private void GenPos()
        {
            Rectangle formRect = new Rectangle();
            this.RectangleToScreen(formRect);
            Rectangle wbRect = new Rectangle();
           wbRect = this.webBrowser1.RectangleToScreen(this.webBrowser1.ClientRectangle);
            Point p = new Point();
            WinAPI.GetCursorPos(out p);

            System.IO.File.AppendAllText("test.xml",
                string.Format("<position x= \"{0}\" y= \"{1}\"></position>\r\n",
                p.X - wbRect.Left, p.Y - wbRect.Top));
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.webBrowser1.GoBack();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Refresh();
        }

        private void textBoxAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.webBrowser1.Navigate(textBoxAddress.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(zhichi));
            t.Start();
        }

        public void zhichi()
        {
            /*697,310
            791,334
            382,466
            382,533*/
            while (DateTime.Now < new DateTime(2013, 10, 29, 13, 00, 00))
                System.Threading.Thread.Sleep(1000);
            int x = this.Left;
            int y = this.Top;
            WinAPI.Click(x + 697, y + 310);
            WinAPI.Click(x + 791, y + 334);

            for (int i = 0; i < 40; i++)
            {
                WinAPI.Click(x + 382, y + 465);
                System.Threading.Thread.Sleep(30000);
            }

            for (int i = 0; i < 40; i++)
            {
                WinAPI.Click(x + 382, y + 532);
                System.Threading.Thread.Sleep(30000);
            }
        }

        private void textBoxLev_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < 400; i++)
                WinAPI.mouse_event(WinAPI.MOUSEEVENTF_LEFTDOWN | WinAPI.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
    }
}
