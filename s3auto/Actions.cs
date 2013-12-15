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
        //private Thread t = null;
        //private Thread tEvent = null;
        //private delegate void EventDel();
        private bool browserIdle = true;
        private readonly int iTotalArmageddonEasy = DateTime.Now.DayOfWeek == DayOfWeek.Friday ? 2 : 1;
        private readonly int iTotalArmageddonHard = DateTime.Now.DayOfWeek == DayOfWeek.Friday ? 2 : 1;
        private readonly int iTotalDungeon = DateTime.Now.DayOfWeek == DayOfWeek.Saturday ? 4 : 2;
        private readonly int iTotalCircle = DateTime.Now.DayOfWeek == DayOfWeek.Sunday ? 4 : 2;
        private const int DetectInterval = 120000;
        private int iDoneArmageddonEasy = 0;
        private int iDoneArmageddonHard = 0;
        private int iDoneDungeon = 0;
        private int iDoneCircle = 0;
        private bool cutinFlag = false;

        public Actions(IBrowser b)
        {
            this.b = b;
        }

        //public void Run()
        //{
        //    t = new Thread(new ThreadStart(DoAll));
        //    t.Start();
            
        //}

        //private void CutIn(EventDel e)
        //{
        //    //if (t != null)
        //    //    t.Abort();
        //    lock (typeof(Actions))
        //    {
        //        cutinFlag = true;
        //    }

        //    tEvent = new Thread(new ThreadStart(e));
        //    tEvent.Name = e.Method.Name;
            
            
        //    tEvent.Start();
        //}

 
        private void Activate()
        {
            lock (this)
            {
                browserIdle = false;
            }
            b.Activate();
        }

        private void Minimize()
        {
            lock (this)
            {
                browserIdle = true;
            }
            b.Minimize();
        }

        public bool Idle
        {
            get
            {
                lock (this)
                {
                    return browserIdle;
                }
            }
        }

        //private void CutIn()
        //{
        //    DateTime dt = DateTime.Now;
        //    if (dt > DateTime.ParseExact("10:30:00", "HH:mm:ss", null)
        //        && dt < DateTime.ParseExact("10:10:00", "HH:mm:ss", null))
        //        CutIn(Event1030);
        //    else if (dt > DateTime.ParseExact("12:00:00", "HH:mm:ss", null)
        //        && dt < DateTime.ParseExact("13:00:00", "HH:mm:ss", null))
        //        CutIn(Event1200);
        //    else if (dt > DateTime.ParseExact("15:30:00", "HH:mm:ss", null)
        //        && dt < DateTime.ParseExact("15:40:00", "HH:mm:ss", null))
        //        CutIn(Event1530);
        //    else if (dt > DateTime.ParseExact("16:00:00", "HH:mm:ss", null)
        //        && dt < DateTime.ParseExact("16:15:00", "HH:mm:ss", null))
        //        CutIn(Event1600);
        //    else if (dt > DateTime.ParseExact("19:00:00", "HH:mm:ss", null)
        //        && dt < DateTime.ParseExact("19:10:00", "HH:mm:ss", null))
        //        CutIn(Event1900);
        //    else if (dt > DateTime.ParseExact("20:00:00", "HH:mm:ss", null)
        //        && dt < DateTime.ParseExact("20:30:00", "HH:mm:ss", null))
        //        CutIn(Event2000);
        //    else if (dt > DateTime.ParseExact("20:30:00", "HH:mm:ss", null)
        //        && dt < DateTime.ParseExact("20:40:00", "HH:mm:ss", null))
        //        CutIn(Event2030);
        //}

        public void Stop()
        {
            lock (this)
            {
                cutinFlag = true;
            }
        }

        public void DoArmageddonEasy()
        {
            b.Activate();
            Thread.Sleep(2000);
            Hangup();
            b.FlashWin.RichangWin.Click();
            b.FlashWin.RichangWin.ButtonArmageddon.Click();
            b.FlashWin.RichangWin.ButtonArmageddon.ButtonArmageddonLatest.Click();
            b.FlashWin.ButtonCancelHangup.Click();
            b.FlashWin.WinArmageddon.ButtonNormal.Click();
            b.FlashWin.WinArmageddon.ButtonAuto.Click();
            b.FlashWin.WinArmageddon.ButtonAutoConfirm.Click();
            List<PointColor> list = b.FlashWin.WinArmageddon.GetInitialColors();
            b.Minimize();

            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(DetectInterval);
                lock (this)
                {
                    if (cutinFlag)
                    {
                        b.Activate();
                        cutinFlag = false;
                        b.FlashWin.WinArmageddon.ButtonStop.Click();
                        b.FlashWin.WinArmageddon.ButtonStopConfirm.Click();
                        b.Minimize();
                        return;
                    }
                }
                
                if (IsColorChange(list))
                    break;
            }
            iDoneArmageddonEasy++;
        }

        public void DoArmageddonHard()
        {
            b.Activate();
            Thread.Sleep(2000);
            Hangup();
            b.FlashWin.RichangWin.Click();
            b.FlashWin.RichangWin.ButtonArmageddon.Click();
            b.FlashWin.RichangWin.ButtonArmageddon.ButtonArmageddonLatest.Click();
            b.FlashWin.ButtonCancelHangup.Click();
            b.FlashWin.WinArmageddon.ButtonHard.Click();
            b.FlashWin.WinArmageddon.ButtonAuto.Click();
            b.FlashWin.WinArmageddon.ButtonAutoConfirm.Click();
            List<PointColor> list = b.FlashWin.WinArmageddon.GetInitialColors();
            b.Minimize();

            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(DetectInterval);
                lock (this)
                {
                    if (cutinFlag)
                    {
                        b.Activate();
                        cutinFlag = false;
                        b.FlashWin.WinArmageddon.ButtonStop.Click();
                        b.FlashWin.WinArmageddon.ButtonStopConfirm.Click();
                        b.Minimize();
                        return;
                    }
                }
                
                if (IsColorChange(list))
                    break;
            }
            b.Activate();
            b.FlashWin.WinArmageddon.ButtonRollStart.Click();
            b.FlashWin.WinArmageddon.ButtonRoll.Click();
            iDoneArmageddonHard++;
            b.Minimize();
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
            b.Activate();
            b.Minimize();
        }

        public void DoDungeon()
        {
            b.Activate();
            Thread.Sleep(2000);
            Hangup();

            b.FlashWin.RichangWin.Click();
            b.FlashWin.RichangWin.ButtonDungeon.Click();
            b.FlashWin.RichangWin.ButtonDungeon.ButtonDungeonLatest.Click();
            b.FlashWin.ButtonCancelHangup.Click();
            b.FlashWin.WinDungeon.Click();
            b.FlashWin.WinDungeon.ButtonAuto.Click();
            b.FlashWin.WinDungeon.ButtonAutoConfirm.Click();
            List<PointColor> list = b.FlashWin.WinDungeon.GetInitialColors();
            b.Minimize();

            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(DetectInterval);
                lock (this)
                {
                    if (cutinFlag)
                    {
                        b.Activate();
                        cutinFlag = false;
                        b.FlashWin.WinDungeon.ButtonStop.Click();
                        b.FlashWin.WinDungeon.ButtonStopConfirm.Click();
                        b.Minimize();
                        return;
                    }
                }
                
                if (IsColorChange(list))
                    break;
            }
            b.Activate();
            b.FlashWin.WinDungeon.ButtonRollStart.Click();
            b.FlashWin.WinDungeon.ButtonRoll.Click();
            iDoneDungeon++;
            b.Minimize();
        }

        public void DoCircle()
        {
            b.Activate();
            Thread.Sleep(2000);
            Hangup();

            b.FlashWin.RichangWin.Click();
            b.FlashWin.RichangWin.ButtonCircle.Click();
            b.FlashWin.RichangWin.ButtonCircle.ButtonCircleLatest.Click();
            b.FlashWin.ButtonCancelHangup.Click();
            b.FlashWin.WinCircle.Click();
            b.FlashWin.WinCircle.ButtonAuto.Click();
            b.FlashWin.WinCircle.ButtonAutoConfirm.Click();
            List<PointColor> list = b.FlashWin.WinDungeon.GetInitialColors();
            b.Minimize();

            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(DetectInterval);
                lock (this)
                {
                    if (cutinFlag)
                    {
                        b.Activate();
                        cutinFlag = false;
                        b.FlashWin.WinCircle.ButtonStop.Click();
                        b.FlashWin.WinCircle.ButtonStopConfirm.Click();
                        b.Minimize();
                        return;
                    }
                }
                
                if (IsColorChange(list))
                    break;
            }
            b.Activate();
            b.FlashWin.WinCircle.ButtonRollStart.Click();
            b.FlashWin.WinCircle.ButtonRoll.Click();
            iDoneCircle++;
            b.Minimize();
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
            HeroIsland hi = new HeroIsland(b);
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
                CityBat cb = new CityBat(b);
                cb.Do();
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday || DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                SupremacyBat sb = new SupremacyBat(b);
                sb.Do();
            }
            else
            {
                CampBat cb = new CampBat(b);
                cb.Do();
            }
        }

        public void Event2030()
        {
            b.Activate();
            Thread.Sleep(2000);
            FactionBat fb = new FactionBat(b);
            fb.Do();
        }

        public void Hangup()
        {
            b.FlashWin.WinHangup.Click();
        }

        public void DoAll()
        {
            //suppose that it will startup before 10:30
            for (int i = 0; i < iTotalArmageddonEasy - iDoneArmageddonEasy; i++)
                DoArmageddonEasy();

            for (int i = 0; i < iTotalArmageddonHard - iDoneArmageddonHard; i++)
                DoArmageddonHard();

            for (int i = 0; i < iTotalDungeon - iDoneDungeon; i++)
                DoDungeon();

            for (int i = 0; i < iTotalCircle - iDoneCircle; i++)
                DoCircle();
        }
    }
}
