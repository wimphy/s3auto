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
        private Thread tEvent = null;
        private delegate void EventDel();
        private bool browserIdle = true;

        public Actions(IBrowser b)
        {
            this.b = b;
        }

        public void Run()
        {
            t = new Thread(new ThreadStart(DoAll));
            t.Start();
        }

        private void CutIn(EventDel e)
        {

            tEvent = new Thread(new ThreadStart(e));
            tEvent.Name = e.Method.Name;

            if (!browserIdle)
                this.Stop();
            tEvent.Start();
        }

        private void CutIn()
        {
            DateTime dt = DateTime.Now;
            if (dt > DateTime.ParseExact("10:30:00", "HH:mm:ss", null)
                && dt < DateTime.ParseExact("10:10:00", "HH:mm:ss", null))
                CutIn(Event1030);
            else if (dt > DateTime.ParseExact("12:00:00", "HH:mm:ss", null)
                && dt < DateTime.ParseExact("13:00:00", "HH:mm:ss", null))
                CutIn(Event1200);
            else if (dt > DateTime.ParseExact("15:30:00", "HH:mm:ss", null)
                && dt < DateTime.ParseExact("15:40:00", "HH:mm:ss", null))
                CutIn(Event1530);
            else if (dt > DateTime.ParseExact("16:00:00", "HH:mm:ss", null)
                && dt < DateTime.ParseExact("16:15:00", "HH:mm:ss", null))
                CutIn(Event1600);
            else if (dt > DateTime.ParseExact("19:00:00", "HH:mm:ss", null)
                && dt < DateTime.ParseExact("19:10:00", "HH:mm:ss", null))
                CutIn(Event1900);
            else if (dt > DateTime.ParseExact("20:00:00", "HH:mm:ss", null)
                && dt < DateTime.ParseExact("20:30:00", "HH:mm:ss", null))
                CutIn(Event2000);
            else if (dt > DateTime.ParseExact("20:30:00", "HH:mm:ss", null)
                && dt < DateTime.ParseExact("20:40:00", "HH:mm:ss", null))
                CutIn(Event2030);
        }

        public void Stop()
        {
            if (t != null)
                t.Abort();
        }

        public void DoArmageddonEasy()
        {
            browserIdle = false;
            b.Activate();
            Thread.Sleep(2000);
            Hangup();
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
            browserIdle = true;
        }

        public void DoArmageddonHard()
        {
            browserIdle = false;
            b.Activate();
            Thread.Sleep(2000);
            Hangup();
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
            browserIdle = true;
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
        {
            browserIdle = false;
            browserIdle = true;
        }

        public void DoDungeon()
        {
            browserIdle = false;
            b.Activate();
            Thread.Sleep(2000);
            Hangup();

            b.FlashWin.RichangWin.Click();
            b.FlashWin.RichangWin.ButtonDungeon.ButtonDungeonLatest.Click();
            b.FlashWin.WinDungeon.Click();
            b.FlashWin.WinDungeon.ButtonAuto.Click();
            b.FlashWin.WinDungeon.ButtonAutoConfirm.Click();
            List<PointColor> list = b.FlashWin.WinDungeon.GetInitialColors();
            b.Minimize();

            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(120000);
                if (IsColorChange(list))
                    break;
            }
            browserIdle = true;
        }

        public void DoCircle()
        {
            browserIdle = false;
            b.Activate();
            Thread.Sleep(2000);
            Hangup();

            b.FlashWin.RichangWin.Click();
            b.FlashWin.RichangWin.ButtonCircle.ButtonCircleLatest.Click();
            b.FlashWin.WinCircle.Click();
            b.FlashWin.WinCircle.ButtonAuto.Click();
            b.FlashWin.WinCircle.ButtonAutoConfirm.Click();
            List<PointColor> list = b.FlashWin.WinDungeon.GetInitialColors();
            b.Minimize();

            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(120000);
                if (IsColorChange(list))
                    break;
            }
            browserIdle = true;
        }

        public void DoMonsterTower()
        {
            b.Activate();
            Thread.Sleep(2000);

            b.FlashWin.WinMTower.Click();
            b.FlashWin.WinMTower.ButtonAuto.Click();
            b.FlashWin.WinMTower.ButtonAutoConfirm.Click();
            b.FlashWin.WinMTower.Exit();
        }

        public void Event1030()
        { }

        public void Event1200()
        {
            b.Activate();
            Thread.Sleep(2000);
            HeroIsland hi = new HeroIsland();
            hi.Do();
        }

        public void Event1530()
        { }

        public void Event1600()
        { }

        public void Event1900()
        { }

        public void Event2000()
        {
            b.Activate();
            Thread.Sleep(2000);

            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                CityBat cb = new CityBat();
                cb.Do();
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday || DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                SupremacyBat sb = new SupremacyBat();
                sb.Do();
            }
            else
            {
                CampBat cb = new CampBat();
                cb.Do();
            }
        }

        public void Event2030()
        {
            b.Activate();
            Thread.Sleep(2000);
            FactionBat fb = new FactionBat();
            fb.Do();
        }

        public void Hangup()
        {
            b.FlashWin.WinHangup.Click();
        }

        public void DoAll()
        {
            //suppose that it will startup before 10:30
            int iArm = 1;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                iArm *= 2;
            for (int i = 0; i < iArm; i++)
            {
                DoArmageddonEasy();
                DoArmageddonHard();
            }
            int iDungeonCnt = 2;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                iDungeonCnt *= 2;
            for (int i = 0; i < iDungeonCnt; i++)
                DoDungeon();
            int iCircleCnt = 2;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                iCircleCnt *= 2;
            for (int i = 0; i < iCircleCnt; i++)
                DoCircle();
        }
    }
}
