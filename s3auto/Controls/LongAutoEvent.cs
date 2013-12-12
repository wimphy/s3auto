using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using s3auto.Browsers;
using System.Drawing;

namespace s3auto.Controls
{
    public class LongAutoEvent
    {
        private IBrowser b;
        private Rectangle rect;
        private S3Button buttonEventLoc;
        private int eventDuration = 30;
        private DateTime timeStart;

        public LongAutoEvent(IBrowser b, Rectangle rect)
        {
            this.b = b;
            this.rect = rect;
            buttonEventLoc = new S3Button(rect);
        }

        public void Do()
        {
            Move();
            buttonEventLoc.Click();
            Join();
            WaitForExit();
        }

        /// <summary>
        /// In minutes, default is 30 min.
        /// </summary>
        public int EventDuration 
        {
            get { return eventDuration; }
            set { eventDuration = value; }
        }

        public DateTime TimeStart
        {
            get { return timeStart; }
            set { timeStart = value; }
        }

        //public S3Button ButtonEventLoc
        //{
        //    get
        //    {
        //        return buttonEventLoc;
        //    }
        //}

        public virtual void Move()
        { }

        public virtual void Join()
        { }

        public virtual void WaitForExit()
        {
            System.Threading.Thread.Sleep(eventDuration * 60 * 1000);
            //exit... in child
        }
    }

    public class CampBat : LongAutoEvent
    { }

    public class SupremacyBat : LongAutoEvent
    { }

    public class CityBat : LongAutoEvent
    { }

    public class FactionBat : LongAutoEvent
    { }

    public class HeroIsland : LongAutoEvent
    { }
}
