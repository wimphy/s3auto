using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using s3auto.Browsers;
using s3auto.Controls;
using System.Drawing;

namespace s3auto
{
    public class Actions
    {
        private IBrowser b = null;
        private Thread t = null;

        public Actions(IBrowser b)
        {
            this.b = b;
        }

        public void Run()
        {
            t = new Thread(new ThreadStart(DoAll));
            t.Start();
        }

        public void Stop()
        {
            if (t != null)
                t.Abort();
        }

        public void DoArmageddonEasy()
        {
            b.Activate();
            Thread.Sleep(2000);
            b.FlashWin.RichangWin.Click();
            b.FlashWin.RichangWin.ButtonArmageddon.ButtonArmageddonLatest.Click();
            b.FlashWin.WinArmageddon.ButtonNormal.Click();
            b.FlashWin.WinArmageddon.ButtonAuto.Click();
            b.FlashWin.WinArmageddon.ButtonAutoConfirm.Click();
            List<PointColor> list = b.FlashWin.WinArmageddon.GetInitialColors();
            b.Minimize();

            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(120000);
                if (IsColorChange(list))
                    break;
            }
        }

        public void DoArmageddonHard()
        {
            b.Activate();
            Thread.Sleep(2000);
            b.FlashWin.RichangWin.Click();
            b.FlashWin.RichangWin.ButtonArmageddon.ButtonArmageddonLatest.Click();
            b.FlashWin.WinArmageddon.ButtonHard.Click();
            b.FlashWin.WinArmageddon.ButtonAuto.Click();
            b.FlashWin.WinArmageddon.ButtonAutoConfirm.Click();
            List<PointColor> list = b.FlashWin.WinArmageddon.GetInitialColors();
            b.Minimize();

            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(120000);
                if (IsColorChange(list))
                    break;
            }
        }

        public bool IsColorChange(List<PointColor> colorBefore, int iWaitforActive = 10000)
        {
            b.Activate();
            Thread.Sleep(iWaitforActive);
            bool flag = true;
            for (int i = 0; i < colorBefore.Count; i++)
            {
                Color cAfter = WinAPI.GetColor(colorBefore[i].p.X, colorBefore[i].p.Y);
                if (cAfter.Equals(colorBefore[i].c))
                    flag &= false;
            }
            return flag;
        }

        public void DoTeamBat()
        { }

        public void DoDungeon() 
        { }

        public void DoCircle()
        { }

        public void DoMonsterTower()
        { }

        public void Event1030()
        { }

        public void Event1200()
        { }

        public void Event1530()
        { }

        public void Event1600()
        { }

        public void Event2000()
        { }

        public void Event2030()
        { }

        public void DoAll()
        {

        }
    }
}
